using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using clipr;
using log4net;
using SETweak;
using SETweak.Logging;
using SETweak.Mods;
using SETweak.ModTool.Fixes;
using SETweak.ModTool.Options;
using Environment = SETweak.Mods.DataBindings.Environment;

namespace ModTool
{
    class Program
    {
        static ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            LogIndent.Configure();
            var opts = CliParser.Parse<Options>(args);
            log.InfoFormat("SETweaks ModTool v{0}", Assembly.GetExecutingAssembly().GetName().Version);

            if (opts.Download != null)
            {
                Download(opts);
            }
            else if (opts.Fix != null)
            {
                Fix(opts);
            }

            if (opts.Pause)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void Fix(Options opts)
        {
            IMod mod = Mod.LocateMod(opts.Fix.Mod, false);

            var availFixers = opts.Fix.Fixes;
            var foundFixers = new List<BaseModFix>();

            using (log.BeginInfo("Loading fixers..."))
            {
                foreach (var type in Assembly.GetCallingAssembly().GetTypes())
                {
                    if (type.IsSubclassOf(typeof(BaseModFix)) && (availFixers.Count == 0 || availFixers.Contains(type.Name)))
                    {
                        foundFixers.Add((BaseModFix)Activator.CreateInstance(type));
                    }
                }
            }

            var files = mod.ListFiles();
            SETweak.Mods.DataBindings.Environment env = null;
            if (files.Contains("Data/Environment.sbc"))
            {
                env = Environment.Load(mod);
            }

            foreach (var fixer in foundFixers)
            {
                fixer.OnMod(mod, files);
                if (env != null)
                    fixer.OnEnvironment(env);
            }
        }

        private static void Download(Options opts)
        {
            foreach (var uri in opts.Download.URIs)
            {
                IMod mod = Mod.LocateMod(uri, opts.Download.Clobber);
                if (opts.Download.Extract)
                {
                    Extract(mod, opts.Download.URIs.Count == 1 ? opts.Download.Output : null);
                }
            }

        }

        private static void Extract(IMod mod, string outDir)
        {
            using (log.BeginInfo("Extracting..."))
            {
                if (mod is WorkshopMod)
                {
                    var wsmod = (WorkshopMod)mod;
                    if (string.IsNullOrEmpty(outDir))
                    {
                        outDir = Utils.StripBadFilenameChars(wsmod.MetaData.Title) + "-" + wsmod.MetaData.PublishedFileID.ToString();
                    }
                    if (Directory.Exists(outDir))
                    {
                        log.WarnFormat("{0} already exists, deleting existing content...", outDir);
                        Directory.Delete(outDir, true);
                    }
                    wsmod.Extract(outDir);
                }
            }
        }
    }
}
