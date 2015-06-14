﻿/**
* VRage Mod (as directory)
* 
* Copyright (c) 2015 Rob "N3X15" Nelson <nexisentertainment@gmail.com>
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.

*/
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
