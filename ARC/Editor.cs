using ARC.Classes;
using ARC.res;
using ARC.Workers;
using FuiEditor;
using FuiEditor.Forms;
using SpecializedHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace ARC
{
    public partial class Editor : Form
    {
        string _filename = string.Empty;

        PS3ARCWorker _worker = null;
        string _workingDirectory = string.Empty;
        bool _shouldSave = false;
        TreeNode _selectedNode;
        string _extractionDirectory = string.Empty;
        string _idName = string.Empty;
        bool _fileOpened = false;
        List<Process> _working = null;
        string _installTid = Properties.Settings.Default.defaultTid;
        string _installIp = Properties.Settings.Default.defaultIp;
        public Editor(string filename)
        {
            InitializeComponent();
            _filename = filename;
        }
        public Editor() { InitializeComponent(); }
        void Open(string filename)
        {
            t(() =>
            {
                ReportProgress(20);
                if (Directory.Exists(_workingDirectory)) Directory.Delete(_workingDirectory, true);
                if (Path.GetExtension(filename) != ".arc") throw new InvalidOperationException("invalid format");
                _worker = new PS3ARCWorker();
                _filename = filename;
                var wp = Res.CreateTmpDirectory("ARC_" + DateTime.Now.ToString("HH-m-ss-yyyy-dd-MM") + "\\");
                _worker.ExtractArchive(_filename, wp);
                Thread.Sleep(500);
                ReportProgress(30, 100);
                _workingDirectory = wp;
                _working = new List<Process>();
                Console.WriteLine("[ARC] " + Directory.GetFiles(wp).Length + " Files extracted.");
                var dirs = Directory.GetDirectories(wp);
                var files = Directory.GetFiles(wp);
                var lstDir = new List<string>();
                var lstFiles = new List<string>();
                var fnName = _workingDirectory + "\\idname.value";
                if (File.Exists(fnName))
                {
                    _idName = File.ReadAllText(fnName);
                    cwinvk(() => NameTextBox.Text = _idName);
                }
                lstDir.AddRange(dirs);
                lstFiles.AddRange(files);
                ReportProgress(45, 100);
                DrawContents(true, lstDir, lstFiles);
                _fileOpened = true;
            });

        }
        void t(Action e)
        {
            var t = new Thread(() => e());
            t.Priority = ThreadPriority.AboveNormal;
            t.IsBackground = true;
            t.Start();
        }
        void cwinvk(Action e) => ControlDelegates.Invoke(this, e);
        void ReportProgress(int elapsed, int of)
        {
            cwinvk(() =>
            {
                var per = (elapsed * 100) / of;
                if (per < 0) per = 0;
                if (per >= 100) { per = 100; }
                indicator.Visible = (per != 100 & per != 0);
                indicator.Value = per;
            });
        }
        void ReportProgress(int elapsed)
        {
            cwinvk(() =>
            {
                var per = (elapsed * 100) / 100;
                if (per < 0) per = 0;
                if (per >= 100) { per = 100; }
                indicator.Visible = (per != 100 & per != 0);
                indicator.Value = per;
            });
        }
        void ReportState(string state = "")
        {
            cwinvk(() =>
            {
                indicatorLabel.Visible = state != "";
                indicatorLabel.Text = state;
            });

        }

        void DrawContents(bool cleaning, List<string> subdirs, List<string> files)
        {
            if (cleaning) cwinvk(() => treeView1.Nodes.Clear());
            int idx = 0;
            foreach (string dir in subdirs)
            {
                var ind = GetTypeIndex(dir);
                ReportProgress(idx, subdirs.Count);
                cwinvk(() => treeView1.Nodes.Add(dir, Path.GetFileName(dir), ind));
                idx++;
            }
            var ftypes = mcre.types.ToList();
            idx = 0;
            foreach (string file in files)
            {
                var ind = GetTypeIndex(file);
                ReportProgress(idx, files.Count);
                if (Path.GetExtension(file) == ".fui")
                {
                    var f = ftypes.Contains(Path.GetFileNameWithoutExtension(file));
                    if (f)
                    {
                        cwinvk(() => treeView1.Nodes.Add(file, Path.GetFileName(file), ind));
                    }
                }
                else cwinvk(() => treeView1.Nodes.Add(file, Path.GetFileName(file), ind));
                idx++;
            }
            ReportProgress(100, 100);
        }
        void SaveFile()
        {
            if (_working?.Count != 0)
            {
                var r = MessageBox.Show(text: "You have running an editor. Save these files and try again.", caption: "Cannot", options: MessageBoxOptions.DefaultDesktopOnly, buttons: MessageBoxButtons.OKCancel, icon: MessageBoxIcon.Warning, defaultButton: MessageBoxDefaultButton.Button1);
                if (r == DialogResult.OK)
                {
                    foreach (Process p in _working) p.Kill();
                }
                else if (r == DialogResult.Cancel) return;
            }
            if (_workingDirectory != null & _filename != string.Empty)
            {
                File.Delete(_filename);
                _worker.BuildArchive(_filename, _workingDirectory);
                _shouldSave = false;
                MessageBox.Show("File saved sucessfully.", "Sucess", MessageBoxButtons.OK, icon: MessageBoxIcon.Asterisk);
            }
            else throw new InvalidOperationException();
        }
        bool NotifySave(out DialogResult r)
        {
            if (!_shouldSave) { r = DialogResult.Ignore; return false; }
            r = MessageBox.Show("You have made changes to the file that have not yet been saved... Do you want to save and exit? \r" +
                "Yes: save and exit.\rNo: exit without save.\rCancel: Abort exiting and continue.", "¿?",
                MessageBoxButtons.YesNoCancel, icon: MessageBoxIcon.Warning);
            return true;
        }
        void SaveFile(string filename)
        {
            if (_workingDirectory != null & _filename != string.Empty)
            {
                _worker.BuildArchive(filename, _workingDirectory);
                _shouldSave = false;
                MessageBox.Show("File saved sucessfully.", "Sucess", MessageBoxButtons.OK, icon: MessageBoxIcon.Asterisk);
            }
            else throw new InvalidOperationException();
        }
        int GetTypeIndex(string filename)
        {
            var ext = Path.GetExtension(filename);
            if (ext == "") return 0;
            else if (ext == ".fui") return 2;
            else if (ext == ".loc") return 3;
            else if (ext == ".png") return 4;
            else return 1;
        }
        FilePath OfdRequest(string name, string title, bool multiselect, string filter)
        {
            var ofd = new OpenFileDialog() { FileName = name, Title = title, Multiselect = multiselect, Filter = filter, };
            var r = ofd.ShowDialog();
            if (r == DialogResult.OK)
            {
                return FilePath.FromFile(ofd.FileName);
            }
            else return null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fn = OfdRequest("media.arc", "Select ARC resource file.", false, ".arc|*.arc");
            if (fn != null)
            {
                Open(fn.FileName);
            }
            else return;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            treeView1.SelectedImageIndex = e.Node.ImageIndex;
            _selectedNode = e.Node;
            OptionsContextMenuStrip.Enabled = Path.HasExtension(_selectedNode.Name);
        }
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            var node = (sender as TreeView).SelectedNode;
            if (e.Button == MouseButtons.Right & node != null)
            {
                OptionsContextMenuStrip.Show(PointToScreen(e.Location));
            }
        }
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = NotifySave(out DialogResult res);
            if (res == DialogResult.Yes)
            {
                SaveFile();
                Close();
            }
            else if (res == DialogResult.Ignore) Dispose();
            else if (res == DialogResult.No) Close();
            else Close();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Select where to save this ARC";
            sfd.DefaultExt = ".arc";
            sfd.Filter = "Media Resource Container|*.arc";
            sfd.AddExtension = true;
            var r = sfd.ShowDialog();
            if (r == DialogResult.OK)
            {
                SaveFile(sfd.FileName);
            }
            sfd.Dispose();
        }
        private void replaceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedNode != null)
            {
                var selFile = FilePath.FromFile(_selectedNode.Name);
                var fn = OfdRequest(selFile.SafeFileName, "Replace \"\"", false, $"Extension|*{selFile.Extension}");
                if (fn != null)
                {
                    File.Delete(selFile.FileName);
                    _shouldSave = true;
                    File.Copy(fn.FileName, selFile.FileName, true);
                }
            }
        }
        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Directory.Exists(_workingDirectory)) return;
            Directory.Delete(_workingDirectory, true);
        }
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_selectedNode != null)
            {
                if (_selectedNode.Name.EndsWith(".fui"))
                {
                    var fui = Application.StartupPath + "\\res\\fuiFix\\FuiEditor.exe";
                    if (File.Exists(fui))
                    {
                        var prc = Process.Start(fui, _selectedNode.Name);
                        prc.OutputDataReceived += (s, ee) => Console.WriteLine("FUI: " + ee);
                        prc.PriorityClass = ProcessPriorityClass.High;
                        _working.Add(prc);
                    }

                }
                else if (_selectedNode.Name.EndsWith(".png")) new PicViewerForm(Image.FromFile(_selectedNode.Name)).ShowDialog();
                else if (!Path.HasExtension(_selectedNode.Name))
                {
                    Process.Start(_selectedNode.Name);
                }
            }
        }
        private void extractFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedNode != null)
            {
                var baseRootCategory = Environment.CurrentDirectory + "\\Extract";
                if (!Directory.Exists(baseRootCategory)) Directory.CreateDirectory(baseRootCategory);
                var path = baseRootCategory + "\\extract_" + (Path.GetFileName(_filename).ToLower()) + "\\" + Path.GetFileName(_selectedNode.Name);

                var dir = Path.GetDirectoryName(path);
                Directory.CreateDirectory(dir);
                Process.Start(dir);
                File.Copy(_selectedNode.Name, path, true);

            }
        }
        private void ButtonOpenExFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_extractionDirectory)) Process.Start(_extractionDirectory);
            else MessageBox.Show("Extract a file first.", "Cannot", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ButtonSetNameOk_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            if (name.Length >= 40) name = name.Substring(0, 35);
            if (name.Length < 5) return;
            else
            {
                var chrs = Path.GetInvalidPathChars().ToArray();
                int i = 0;
                while (i < chrs.Length)
                {
                    name = name.Replace(chrs[i], ' ');
                    i++;
                }
                File.WriteAllText(_workingDirectory + "idname.value", name);
            }
        }

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_workingDirectory)) Process.Start(_workingDirectory);
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mistycal.DarkMode(this, true, treeView1, MainToolStrip);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) => SaveFile();

        private void saveToPS3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stopwatch ptime;
            t(() =>
            {
                ptime = Stopwatch.StartNew();
                var baseDir = "ftp://{0}/dev_hdd0/game";
                var r = PromptForm.Show("Ps3 System IP", "Install ARC on PS3", "cancel", "ok");
                var sucess = IPAddress.TryParse(r.Value, out IPAddress value);
                ReportProgress(20);
                ReportState("Connecting..");
                if (sucess == true)
                {
                    var url = string.Format(baseDir, value.ToString());
                    var filename = _workingDirectory + "MediaOnline.arc";
                    SaveFile(filename);
                    Thread.Sleep(50);
                    if (File.Exists(filename))
                    {
                        ReportProgress(30);
                        bool reach = TcpReachable(value.ToString(), 21);
                        if (!reach)
                        {

                            MessageBox.Show("Cannot reach external system.", "Operation cancelled.");
                        }
                        else
                        {
                            string gameRegion = "";
                            var promptResult = PromptForm.Show("Game Installation TitleId: ", "¿?", out PromptForm pform, "", "OK");
                            cwinvk(() => gameRegion = promptResult.Value);
                            if (gameRegion.Length > 9)
                            {
                                MessageBox.Show("Error the title code cannot be longer than 9 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                ReportProgress(50);
                                ReportState("Parsing TID");
                                var tidChars = gameRegion.ToCharArray();
                                int result = -1;
                                string resultMessage = "unknown exception.";
                                int chInd = 0;
                                foreach (char c in tidChars)
                                {
                                    bool flag2 = ((chInd > 4) & char.IsLower(c)) || ((chInd > 4) & !char.IsNumber(c)) || ((chInd > 4) & char.IsSymbol(c));
                                    bool flag1 = char.IsPunctuation(c) || char.IsLower(c) || char.IsSeparator(c) || char.IsSymbol(c);
                                    if (flag1) resultMessage = "Invalid tid first part.";
                                    if (flag2) resultMessage = "Invalid tid second part.";
                                    if (flag2 & flag1) resultMessage = "TID is invalid";
                                    result = bt(!(flag1 && flag2));
                                    chInd++;
                                }
                                if (result == -1)
                                {
                                    MessageBox.Show(string.Format("Error. Operation cancelled with message: {0}", resultMessage), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ReportProgress(70);
                                    bool HasGame = ftpExists(url + "/" + gameRegion + "/PARAM.SFO");
                                    ReportState("Game check returned " + HasGame.ToString().ToLower());
                                    if (HasGame)

                                    {
                                        var arcUrl = url + "/" + gameRegion + "/USRDIR/Common/Media/MediaPS3.arc";
                                        bool arcExist = ftpExists(arcUrl);
                                        if (arcExist)
                                            FtpRename(arcUrl, string.Format("MediaPS3_Backup{0}.arc", DateTime.Now.Ticks - int.MaxValue), new NetworkCredential("", ""));
                                        ReportState("Preparing upload..");
                                        ReportProgress(80);
                                        ReportState(string.Format("Uploading {0} MBs", new System.IO.FileInfo(filename).Length / 1000));
                                        ftpUpload(filename, arcUrl);
                                        Thread.Sleep(100);
                                        ReportState("resting 100ms without exceptions..");
                                        ptime.Stop();
                                        ReportState("Sucess!");
                                        MessageBox.Show(string.Format("Operation Finished on {0}ms", ptime.ElapsedMilliseconds));

                                    }
                                    else MessageBox.Show($"{gameRegion} is not installed on the specified system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ReportProgress(100);
                                    ReportState();
                                }
                            };
                        }
                    }
                    else MessageBox.Show("Error ocurred while saving ARC.", "!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Unparseable IP value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            ptime = null;
            ReportProgress(100);
        }
        private void FtpRename(string ftpFileName, string newSafeFileName, NetworkCredential credential)
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;

            ftpRequest = (FtpWebRequest)WebRequest.Create(ftpFileName);
            ftpRequest.Credentials = credential;
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            ftpRequest.Method = WebRequestMethods.Ftp.Rename;
            ftpRequest.RenameTo = newSafeFileName;
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpResponse.Close();
            ftpRequest = null;

        }
        int bt(bool value)
        {
            return value ? 0 : -1;
        }
        private bool TcpReachable(string host, int port)
        {
            try
            {
                TcpClient tcp = new TcpClient();
                tcp.Connect(host, port);
                Thread.Sleep(500);
                tcp.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        bool ftpExists(string ftpFilename)
        {
            var request = (FtpWebRequest)WebRequest.Create
    (ftpFilename);
            request.Credentials = new NetworkCredential("user", "pass");
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                throw;
            }
        }
        private List<string> ftpListContainer(string ftpUrl, NetworkCredential e)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = e;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();
                reader.Close();
                response.Close();
                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception ERR)
            {
                MessageBox.Show(ERR.GetType().FullName + ": " + ERR.Message, ERR.Source, MessageBoxButtons.OK);
                return null;
            }
        }
        private void ftpUpload(string local, string ftpurl)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpurl);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // This example assumes the FTP site uses anonymous logon.  
            request.Credentials = new NetworkCredential("username", "password");
            request.Proxy = null;
            request.KeepAlive = true;
            request.UseBinary = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Copy the contents of the file to the request stream.  
            StreamReader sourceStream = new StreamReader(local);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("UPD status {0}", response.StatusDescription);
        }
        void CheckSetUi()
        {
            if (!Directory.Exists(_workingDirectory) & _fileOpened)
            {
                treeView1.Nodes.Clear();
                _filename = "";
                _workingDirectory = "";
                _shouldSave = false;
                MessageBox.Show("Extracted resource files for visualization have been removed. So you can no longer continue editing the current module. Reopen a file.", "Filedata changed.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            toolStripMenuItem1.Enabled = saveToolStripMenuItem.Enabled = NameTextBox.Enabled = saveToPS3ToolStripMenuItem.Enabled = File.Exists(_filename);

        }
        private void toolStripButton2_DropDownOpening(object sender, EventArgs e) => CheckSetUi();
        private void Editor_Activated(object sender, EventArgs e) => CheckSetUi();
        private void Editor_Deactivate(object sender, EventArgs e) => CheckSetUi();

        private void defaultIPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
