using System.Collections.Generic;
using clipr;

namespace SETweak.ModTool.Options
{
    public class FixVerb
    {
        [PositionalArgument(0, Description = "Mod to fix")]
        public string Mod { get; set; }

        [PositionalArgument(1, Description = "Fixes to apply.  Default is all.")]
        public List<string> Fixes { get; set; }

        [NamedArgument('o', "output", NumArgs = 1, Required = false, Description = "Name of directory that the fixed mod will be extracted to. Default: NAME-FIXED")]
        public string Output { get; set; }
    }
}
