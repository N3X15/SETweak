/**
* Space Engineers path detection
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

namespace SETweaks
{
    public class SEPaths
    {
        private static string _modDir;
        public static string ModDir
        {
            get
            {
                if (string.IsNullOrEmpty(_modDir))
                    _modDir = Path.Combine(SEAppDataDir, "Mods");
                return _modDir;
            }
        }

        private static string _seAppDataDir;
        public static string SEAppDataDir
        {
            get
            {
                if (string.IsNullOrEmpty(_seAppDataDir))
                    _seAppDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SpaceEngineers");
                return _seAppDataDir;
            }
        }

        private static string _tempDir;
        public static string TempDir
        {
            set
            {
                _tempDir = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_tempDir))
                    _tempDir = Path.Combine(Path.GetTempPath(), "SETweak");
                return _tempDir;
            }
        }
    }
}
