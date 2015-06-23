using clipr;

namespace SETweak.ModTool.Options
{
    public class Options
    {
        [Verb(Name = "download", Description = "Download and optionally extract a Steam Workshop mod.")]
        [Verb(Name = "dl")]
        public DownloadVerb Download { get; set; }

        [NamedArgument("pause", Action = ParseAction.StoreTrue)]
        public bool Pause { get; set; }

        [Verb(Name = "fix", Description = "Apply any of a number of ModFixes to a mod.  Note:  Will extract the mod.")]
        public FixVerb Fix { get; set; }
    }
}
