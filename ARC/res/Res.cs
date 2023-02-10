using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ARC.Classes
{
    public class Res
    {
        public static string Path { get => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\solitaireModding"; }
        public static void SaveTmpFile(byte[] data, string safefilename) => File.WriteAllBytes(Path + "\\" + safefilename, data);
        public static string InvokeTempPath()
        {
            if (Directory.Exists(Path))
            {
                return Path;
            }
            else
            {
                Directory.CreateDirectory(Path);
                return Path;
            }
        }
        public static byte[] ReadTmpFile(string safefilename)
        {
            string fn = Path + "\\" + safefilename;
            if (File.Exists(fn)) return File.ReadAllBytes(fn);
            else return null;
        }
        public static string ReadTxtFile(string safefilename)
        {
            return File.ReadAllText(Path + "\\" + safefilename);
        }
        public static string SaveTmpDictionary(Dictionary<string, string> dic, string safefilename)
        {
            string txtc = "";
            foreach (var c in dic)
            {
                txtc += c.Key + " : " + c.Value;
            }
            File.WriteAllText(Path + "\\" + safefilename, txtc);
            return Path + "\\" + safefilename;
        }
        public static Dictionary<string, string> ReadTmpDictionary(string safefilename)
        {
            var fn = Path + "\\" + safefilename;
            var txt = File.ReadAllLines(fn);
            var dc = new Dictionary<string, string>();
            foreach (var line in txt)
            {
                var sp = line.Split(':');
                dc.Add(sp[0], sp[1]);
            }
            return dc;
        }
        public static int FilesCount { get => Directory.GetFiles(Path).Length; }
        public static int DirectoriesCount { get => Directory.GetDirectories(Path).Length; }
        public static void DeleteTmpFile(string safefilename) => File.Delete(Path + "\\" + safefilename);
        public static string CreateTmpDirectory(string safefilename)
        {
            Directory.CreateDirectory(Path + "\\" + safefilename);
            return Path + "\\" + safefilename;
        }
        public static long GetTmpFileLength(string safefilename) => File.ReadAllBytes(Path + "\\" + safefilename).Length;
        public static string GetDirectory(string safefilename) => Path + "\\" + safefilename;
        public static void Upload(string ftp, string filename) => new WebClient().UploadFile(ftp, filename);
        public static byte[] Download(string ftp) => new WebClient().DownloadData(ftp);
        public static string DownloadString(string ftp) => new WebClient().DownloadString(ftp);
        public static void UploadString(string ftp, string str) => new WebClient().UploadString(ftp, str);
        private Res() { }

    }
}
