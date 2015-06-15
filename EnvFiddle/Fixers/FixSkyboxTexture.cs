using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvFiddle.Fixers
{
    public class FixSkyboxTexture : BaseFixer
    {
        public override void Fix(SETweak.Mods.DataBindings.Environment env)
        {
            if (!env.EnvironmentTexture.EndsWith(".dds"))
            {
                Console.WriteLine("Adding .dds to EnvironmentTexture...");
                env.EnvironmentTexture += ".dds";
            }
        }
    }
}
