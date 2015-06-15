using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace EnvFiddle.Fixers
{
    public class FixSkyboxTexture : BaseFixer
    {
        static ILog log = LogManager.GetLogger(typeof(FixSkyboxTexture));
        public override void Fix(SETweak.Mods.DataBindings.Environment env)
        {
            if (env != null && env.EnvironmentTexture!=null && !env.EnvironmentTexture.EndsWith(".dds"))
            {
                log.Info("Adding .dds to EnvironmentTexture...");
                env.EnvironmentTexture += ".dds";
            }
        }
    }
}
