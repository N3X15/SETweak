using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SETweaks.Mods
{
    public class DirectoryMod : IMod, IDisposable
    {
        private string path;
        public DirectoryMod(string path)
        {
            this.path = path;
        }

        public IEnumerable<string> ListFiles()
        {
            return Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
        }

        public Stream ReadFile(string name)
        {
            return File.OpenRead(Path.Combine(path, name));
        }

        public Stream WriteFile(string name)
        {
            return File.OpenWrite(Path.Combine(path, name));
        }

        public void RemoveFile(string name)
        {
            File.Delete(Path.Combine(path, name));
        }

        public void Dispose()
        {
            return;
        }

        public void CopyTo(string p)
        {
            if (Directory.Exists(p))
                Directory.Delete(p, true);
            Utils.CopyTree(path, p);
        }
    }
}
