using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC.Classes
{
    internal class FilePath
    {
        public string FileName { get; private set; }
        public string DirectoryName { get; private set; }
        public DirectoryInfo DirectoryInfo { get => new DirectoryInfo(DirectoryName); }
        public string SafeFileName { get; private set; }
        public string Extension { get; private set; }
        public long GetLength()
        {
            return File.ReadAllBytes(FileName).Length;
        }
        public static FilePath FromFile(string filename)
        {
            if (File.Exists(filename))
            {
                var fn = new FilePath();
                fn.FileName = filename;
                fn.DirectoryName = Path.GetDirectoryName(filename);
                fn.SafeFileName = Path.GetFileNameWithoutExtension(filename);
                fn.Extension = Path.GetExtension(filename);
                return fn;
            }
            else throw new FileNotFoundException();
        }
        private FilePath() { }

    }
}
