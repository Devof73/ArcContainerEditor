﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using FuiEditor.Properties;
using FuiEditor.Data.FJUI.Utils;
using System.Threading;
using FuiEditor.Data.FJUI;
using SpecializedHelpers;


namespace FuiEditor.Forms
{
    public partial class MainWindow : Form
    {
        private static readonly byte[] PngStartPattern =
        {
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A
        };

        private string currentOpenFui = null;
        private bool shouldSaveFui = false;
        private byte[] fuiMainBytes;
        private List<FuiImageInfo> fuiImageInfo = new List<FuiImageInfo>();
        private List<byte[]> originalImagesData = new List<byte[]>();
        private List<ImageFormat> originalImageFormats = new List<ImageFormat>();
        private bool _dark = false;

        public MainWindow() => InitializeComponent();
        public MainWindow(string fn)
        {
            InitializeComponent();
            fileOpenStripMenu.Enabled = false;
            OpenFui(fn);

        }

        private void OnClickFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Fui files (*.fui)|*.fui|All Files (*.*)|*.*";
            fileDialog.Title = Resources.DialogOpenFui;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                OpenFui(filepath);
            }
        }

        private void OnClickFileSave(object sender, EventArgs e)
        {
            SaveFui(currentOpenFui);
        }

        private void OnClickFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                Filter = "Fui Files (*.fui)|*.fui",
                Title = Resources.DialogSaveFui,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = fileDialog.FileName;
                SaveFui(filepath);
            }
        }

        private void OnClickFileExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnClickImageReplace(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show(Resources.DialogSelectImage, Resources.DialogInfo);
                return;
            }

            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
                Resources.DialogCorrectColor, false);

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog(Resources.DialogReplaceImage)
            {
                Filters =
                {
                    new CommonFileDialogFilter("PNG", "*.png"),
                    new CommonFileDialogFilter("JPEG", "*.jpg;*.jpeg"),
                    new CommonFileDialogFilter(Resources.DialogAllFiles, "*.*")
                },
                Controls =
                {
                    correctColorCb
                },
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                int selected = imageListView.SelectedIndices[0];
                string filepath = fileDialog.FileName;
                byte[] filedata = File.ReadAllBytes(filepath);
                ImageFormat originalFormat = originalImageFormats[selected];

                using (MemoryStream stream = new MemoryStream(filedata, false))
                {
                    Image imageLoaded = Image.FromStream(stream);

                    if (!correctColorCb.IsChecked && originalFormat == imageLoaded.RawFormat)
                    {
                        originalImagesData[selected] = filedata;
                    }
                    else
                    {
                        if (correctColorCb.IsChecked)
                        {
                            ImageUtils.ReverseColorRB((Bitmap)imageLoaded);
                        }

                        MemoryStream saveStream = new MemoryStream();

                        imageLoaded.Save(saveStream, originalFormat);
                        originalImagesData[selected] = saveStream.ToArray();

                        saveStream.Dispose();
                    }

                    imageList.Images[selected].Dispose();
                    imageList.Images[selected] = ImageUtils.CreateThumbnail(imageLoaded, imageList.ImageSize);
                    imageListView.Items[selected].Text = $"{selected} - {imageLoaded.Width}x{imageLoaded.Height}";

                    imageLoaded.Dispose();
                }

                shouldSaveFui = true;
            }
        }

        private void OnClickImageSave(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show(Resources.DialogSelectImage, Resources.DialogInfo);
                return;
            }

            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
                Resources.DialogCorrectColor, false);

            ImageFormat[] imageFormats =
            {
                ImageFormat.Png,
                ImageFormat.Jpeg
            };

            CommonSaveFileDialog fileDialog = new CommonSaveFileDialog(Resources.DialogSaveImage)
            {
                Filters =
                {
                    new CommonFileDialogFilter("PNG", "*.png"),
                    new CommonFileDialogFilter("JPEG", "*.jpg;*.jpeg")
                },
                Controls =
                {
                    correctColorCb
                },
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string filepath = fileDialog.FileName;
                int selected = imageListView.SelectedIndices[0];
                byte[] imageData = originalImagesData[selected];
                ImageFormat saveFormat = imageFormats[fileDialog.SelectedFileTypeIndex - 1];
                ImageFormat imageFormat = originalImageFormats[selected];

                if (!correctColorCb.IsChecked && saveFormat == imageFormat)
                {
                    File.WriteAllBytes(filepath, imageData);
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image imageSave = Image.FromStream(stream);

                        if (correctColorCb.IsChecked)
                        {
                            ImageUtils.ReverseColorRB((Bitmap)imageSave);
                        }

                        imageSave.Save(filepath, saveFormat);
                        imageSave.Dispose();
                    }
                }
            }

            fileDialog.Dispose();
        }

        private void OnClickFileSaveAllImages(object sender, EventArgs e)
        {
            Dictionary<ImageFormat, string> extensions = new Dictionary<ImageFormat, string>()
            {
                {
                    ImageFormat.Png, ".png"
                },
                {
                    ImageFormat.Jpeg, ".jpg"
                }
            };

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog(Resources.DialogSaveAllImages)
            {
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                string filepathBase = Path.Combine(
                    directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");

                for (int i = 0; i < originalImageFormats.Count; i++)
                {
                    ImageFormat imageFormat = originalImageFormats[i];
                    FuiImageInfo imageInfo = fuiImageInfo[i];
                    int attribute = imageInfo.Attribute;
                    string filepath;

                    if (extensions.ContainsKey(imageFormat))
                    {
                        string extension = extensions[imageFormat];

                        filepath = string.Format(filepathBase, i, extension);
                    }
                    else
                    {
                        filepath = string.Format(filepathBase, i, ".unknown");
                    }

                    File.WriteAllBytes(filepath, originalImagesData[i]);
                }
            }
        }

        private void OnClickImageEditAttribute(object sender, EventArgs e)
        {
            throw new NotImplementedException("Edit Attribute");
        }

        private void OnClickImagesSave(object sender, EventArgs e)
        {
            Dictionary<ImageFormat, string> extensions = new Dictionary<ImageFormat, string>()
            {
                {
                    ImageFormat.Png, ".png"
                },
                {
                    ImageFormat.Jpeg, ".jpg"
                }
            };

            CommonFileDialogCheckBox correctColorCb = new CommonFileDialogCheckBox("correctColorCb",
                Resources.DialogCorrectColor, false);

            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog(Resources.DialogSaveSelectedImages)
            {
                Controls =
                {
                    correctColorCb
                },
                IsFolderPicker = true,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string directorySelected = fileDialog.FileName;
                string filepathBase = Path.Combine(
                    directorySelected, Path.GetFileNameWithoutExtension(currentOpenFui) + "_{0}{1}");
                int[] selectedIndices = imageListView.SelectedIndices.Cast<int>().ToArray();

                for (int i = 0; i < selectedIndices.Length; i++)
                {
                    int selected = selectedIndices[i];
                    ImageFormat imageFormat = originalImageFormats[selected];
                    FuiImageInfo imageInfo = fuiImageInfo[selected];
                    byte[] filedata = originalImagesData[selected];
                    string filepath;

                    if (extensions.ContainsKey(imageFormat))
                    {
                        string extension = extensions[imageFormat];

                        filepath = string.Format(filepathBase, i, extension);
                    }
                    else
                    {
                        filepath = string.Format(filepathBase, i, ".unknown");
                    }

                    if (!correctColorCb.IsChecked)
                    {
                        File.WriteAllBytes(filepath, filedata);
                    }
                    else
                    {
                        using (MemoryStream stream = new MemoryStream(filedata, false))
                        {
                            Image imageSave = Image.FromStream(stream);

                            ImageUtils.ReverseColorRB((Bitmap)imageSave);
                            imageSave.Save(filepath, imageFormat);

                            imageSave.Dispose();
                        }
                    }
                }
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.sett_dark = _dark;
            Properties.Settings.Default.Save();
            if (shouldSaveFui && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = NotifySave();
            }
        }

        private void OnOpendFui(string filepath)
        {
            currentOpenFui = filepath;
            fileSaveStripMenu.Enabled = true;
            fileSaveAsStripMenu.Enabled = true;
            fileSaveAllImagesStripMenu.Enabled = true;

            SetStatus(Path.GetFileName(filepath));
        }

        private void OnOpenFui()
        {
            foreach (Image image in imageList.Images)
            {
                image.Dispose();
            }
            fuiImageInfo.Clear();
            originalImagesData.Clear();
            originalImageFormats.Clear();
            imageList.Images.Clear();
            imageListView.Items.Clear();
            currentOpenFui = null;
            fileSaveStripMenu.Enabled = false;
            fileSaveAsStripMenu.Enabled = false;
            shouldSaveFui = false;
            fileSaveAllImagesStripMenu.Enabled = false;

            SetStatus(null);
        }

        private void OnSavedFui(string filepath)
        {
            shouldSaveFui = false;
            MessageBox.Show(string.Format(Resources.DialogSavedFui, filepath));
        }

        private bool NotifySave()
        {
            DialogResult result = MessageBox.Show(Resources.DialogNotifySave, Resources.DialogWarning, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                return false;
            }

            return true;
        }

        private void SetStatus(string message)
        {
            if (message != null)
            {
                Text = message + " - Fui Editor";
            }
            else
            {
                Text = "Fui Editor";
            }
        }

        private void OpenFui(string filepath)
        {
            OnOpenFui();

            byte[] filedata = File.ReadAllBytes(filepath);
            int pngIndex = ArrayUtils.SearchBytes(filedata, 0, PngStartPattern);
            if (pngIndex < 0)
            {
                MessageBox.Show(Resources.DialogFailedToOpen, Resources.DialogError);
                return;
            }

            FuiImageInfo[] imageInfo = FuiUtils.GetImageInfo(filedata, pngIndex);
            List<byte[]> imagesData = FuiUtils.GetImagesData(filedata, pngIndex, imageInfo);
            originalImagesData.AddRange(imagesData);
            var t = new Thread(() =>
            {
                for (int i = 0; i < imagesData.Count; i++)
                {
                    byte[] imageData = imagesData[i];
                    using (MemoryStream stream = new MemoryStream(imageData, false))
                    {
                        cinvk(() =>
                        {
                            Image image = Image.FromStream(stream);
                            originalImageFormats.Add(image.RawFormat);
                            imageList.Images.Add(ImageUtils.CreateThumbnail(image, imageList.ImageSize));
                            imageListView.Items.Add($"{i} - {image.Width}x{image.Height}", i);
                            image.Dispose();
                            rpgr((i * 100) / imagesData.Count);

                        });
                    }
                }
                rpgr(100);
                cinvk(() =>
                {
                    fuiMainBytes = filedata.Take(pngIndex - imageInfo.Length * FuiImageInfo.NativeSize).ToArray();
                    fuiImageInfo.AddRange(imageInfo);
                    LabelTotalEntries.Text = "Total Entries: " + imagesData.Count;
                    OnOpendFui(filepath);
                });
            });
            t.Start();
        }
        void cinvk(Action e) => ControlDelegates.Invoke(this, e);
        void rpgr(int i)
        {
            if (i < 101 & i >= 0)
            {
                cinvk(() =>
                {
                    ImgLoadingIndicator.Visible = (i < 100);
                    ImgLoadingIndicator.Value = i;
                });
            }

        }

        private void SaveFui(string filepath)
        {
            List<byte> fuiBytes = new List<byte>();
            List<byte> imageSection = new List<byte>();
            int currentOffset = 0;

            fuiBytes.AddRange(fuiMainBytes);

            for (int i = 0; i < fuiImageInfo.Count; i++)
            {
                FuiImageInfo imageInfo = fuiImageInfo[i];
                using (MemoryStream imageStream = new MemoryStream(originalImagesData[i], false))
                {
                    Image imageSave = Image.FromStream(imageStream);

                    byte[] imageBytes = originalImagesData[i];
                    imageInfo.Width = imageSave.Width;
                    imageInfo.Height = imageSave.Height;
                    imageInfo.ImageOffset = currentOffset;
                    imageInfo.ImageSize = imageBytes.Length;

                    fuiBytes.AddRange(imageInfo.ToByteArray());
                    imageSection.AddRange(imageBytes);

                    currentOffset += imageBytes.Length;
                    imageSave.Dispose();
                }
            }

            fuiBytes.AddRange(imageSection);
            File.WriteAllBytes(filepath, FuiUtils.ProcessHeader(fuiBytes.ToArray()));

            OnSavedFui(filepath);
        }

        private void invertColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageListView.SelectedIndices.Count < 1)
            {
                MessageBox.Show(Resources.DialogSelectImage, Resources.DialogInfo);
                return;
            }


            int selected = imageListView.SelectedIndices[0];
            byte[] filedata = originalImagesData[selected];
            ImageFormat originalFormat = originalImageFormats[selected];

            using (MemoryStream stream = new MemoryStream(filedata, false))
            {
                Image imageLoaded = Image.FromStream(stream);

                if (originalFormat == imageLoaded.RawFormat)
                {
                    originalImagesData[selected] = filedata;
                }
                else
                {

                    ImageUtils.ReverseColorRB((Bitmap)imageLoaded);


                    MemoryStream saveStream = new MemoryStream();

                    imageLoaded.Save(saveStream, originalFormat);
                    originalImagesData[selected] = saveStream.ToArray();

                    saveStream.Dispose();
                }

                imageList.Images[selected].Dispose();
                imageList.Images[selected] = ImageUtils.CreateThumbnail(imageLoaded, imageList.ImageSize);
                imageListView.Items[selected].Text = $"{imageLoaded.Width}x{imageLoaded.Height}";

                imageLoaded.Dispose();
            }

            shouldSaveFui = true;

        }
        Thread _previewThread;
        internal int _selectedIndex = -1;
        internal byte[] SelectedData { get; private set; }
        private void imageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ind = _selectedIndex = (imageListView.SelectedIndices.Count != 0 ? imageListView.SelectedIndices[0] : -1);
            LabelSelectedIndex.Text = "Index: " + ind;
            if (ind != -1)
            {

                if (originalImagesData.Count > ind)
                {
                    if (_previewThread != null) { _previewThread.Abort(); Thread.Sleep(100); _previewThread = null; }
                    var t = new Thread(() =>
                    {
                        SetPreviewState(true);
                        var bmp = new Bitmap(new MemoryStream(SelectedData = originalImagesData[ind]));
                        if (bmp.Height < 120 & bmp.Width < 120) bmp = Mistycal.UpscaleGraphic(bmp, 4, false);
                        ControlDelegates.Invoke(this, () => { PicPreview.Image = bmp; LabelSelImgSize.Text = "Selected Image Size: " + bmp.Width + "x" + bmp.Height; });
                        SetPreviewState(false);//☠️👍
                    });
                    t.Start();
                    _previewThread = t;
                }
            }
        }
        internal void SetPreviewState(bool state)
        {
            ControlDelegates.Invoke(this, () =>
            {
                ButtonStopPreview.Visible = state;
                PreviewLoadingIndicator.Visible = state;
            });

        }
        internal void FullPic()
        {
            if (_selectedIndex != -1)
            {
                new PicViewerForm(Image.FromStream(new MemoryStream(SelectedData))).ShowDialog();
            }
        }
        internal void ToggleTheme() => _dark = Mistycal.DarkMode(this, _dark = !_dark, this, splitContainer1, imageListView, statusStrip1);
        internal void ToggleTheme(bool state) => _dark = Mistycal.DarkMode(this, state, this, splitContainer1, imageListView, statusStrip1);

        private void imageListView_MouseDoubleClick(object sender, MouseEventArgs e) => FullPic();

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e) => ToggleTheme();

        private void MainWindow_Load(object sender, EventArgs e) => ToggleTheme(Settings.Default.sett_dark);
    }
}
