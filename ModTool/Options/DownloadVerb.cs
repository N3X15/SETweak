using System.Collections.Generic;
using clipr;

namespace SETweak.ModTool.Options
{
    public class DownloadVerb
    {
        [PositionalArgument(0, NumArgs = 1, Constraint = NumArgsConstraint.AtLeast, Action = ParseAction.Append, Description = "URL or ID of the Steam Workshop mod(s) to download.")]
        public List<string> URIs { get; set; }

        [NamedArgument('x', "extract", Action = ParseAction.StoreTrue)]
        public bool Extract { get; set; }

        [NamedArgument('C', "clobber", Action = ParseAction.StoreTrue)]
        public bool Clobber { get; set; }

        [NamedArgument('o', "output", NumArgs = 1, Constraint = NumArgsConstraint.AtMost, Description = "Where to put the extracted file.  Only works if one URI is specified, and --extract is set.")]
        public string Output { get; set; }
    }
}
