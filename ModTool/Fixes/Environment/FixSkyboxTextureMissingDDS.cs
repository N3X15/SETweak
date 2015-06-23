using log4net;

namespace SETweak.ModTool.Fixes.Environment
{
    public class FixSkyboxTextureMissingDDS : BaseModFix
    {
        static ILog log = LogManager.GetLogger(typeof(FixSkyboxTextureMissingDDS));
        public override void OnEnvironment(Mods.DataBindings.Environment env)
        {
            if (env != null && env.EnvironmentTexture != null && !env.EnvironmentTexture.EndsWith(".dds"))
            {
                log.Info("Adding .dds to EnvironmentTexture...");
                env.EnvironmentTexture += ".dds";
            }
        }
    }
}
