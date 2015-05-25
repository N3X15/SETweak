using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SETweaks.Mods
{
    public interface IMod
    {
        //ModMetadata Metadata;

        IEnumerable<string> ListFiles();

        Stream ReadFile(string name);
        void RemoveFile(string name);
        Stream WriteFile(string name);
    }
}
