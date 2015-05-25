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
