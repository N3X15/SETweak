using System.Collections.Generic;
using SETweak.Mods;

namespace SETweak.ModTool.Fixes
{
    public class BaseModFix
    {
        internal BaseModFix()
        {}

        public virtual void OnEnvironment(SETweak.Mods.DataBindings.Environment env) { }
        public virtual void OnMod(IMod mod, IEnumerable<string> files) { }
    }
}
