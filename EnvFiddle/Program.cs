using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clipr;
using SETweaks.Mods;
using System.IO;
using System.Xml.Serialization;
using Environment = SETweaks.Mods.DataBindings.Environment;
using System.Reflection;
using System.Xml;

namespace EnvFiddle
{
    class Program
    {
        static Environment DarkShadows;
        const string wsPrefix = "http://steamcommunity.com/sharedfiles/filedetails/?id=";

        static IMod LocateMod(string path)
        {
            ulong modID;
            if (path.StartsWith(wsPrefix))
            {
                path = path.Remove(wsPrefix.Length);
            }
            if (ulong.TryParse(path, out modID))
            {
                using (var wsmod = new WorkshopMod(modID))
                {
                    wsmod.Download(false);
                    return wsmod.Extract();
                }
            }
            else
            {
                return new DirectoryMod(path);
            }
        }

        static void CopyIfNotNull(Environment a, Environment b, Environment defaults, FieldInfo field)
        {
            object value = field.GetValue(b);
            object defaultValue = field.GetValue(defaults);
            //Console.WriteLine("  {0} Default: {1}", field.Name, value);
            if (value == null || value.Equals(defaultValue))
                return;
            field.SetValue(a, value);
            Console.WriteLine("  Set {0} to {1}.", field.Name, value);
        }
        static void EnvMerge(Environment a, Environment b)
        {
            var defaults = new Environment();
            foreach (var finfo in typeof(Environment).GetFields())
            {
                CopyIfNotNull(a, b, defaults, finfo);
            }
        }

        static string BinDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        static void Main(string[] args)
        {
            var opt = CliParser.Parse<Options>(args);

            if (opt.DarkShadows)
            {
                var preset = Path.Combine(BinDir(), "Presets", "Special", "DarkShadows.xml");
                Console.WriteLine("Pre-loading preset {0}...", preset);
                using (var stream = File.OpenRead(preset))
                {
                    DarkShadows = LoadEnv(stream);
                }
            }

            IMod mod = LocateMod(opt.Path);

            SETweaks.Mods.DataBindings.Environment env = LoadEnv(mod.ReadFile("Data/Environment.sbc"));

            if (opt.Presets !=null && opt.Presets.Count > 0)
            {
                foreach (var presetName in opt.Presets)
                {
                    Console.WriteLine("Loading preset {0}...", presetName);
                    Environment p_env;
                    using (var stream = File.OpenRead(presetName))
                    {
                        p_env = LoadEnv(stream);
                    }
                    Console.WriteLine("Merging preset...");
                    EnvMerge(env, DarkShadows);
                }
            }

            if (opt.DarkShadows)
            {
                Console.WriteLine("Configuring for dark shadows...");
                EnvMerge(env, DarkShadows);
            }

            if (opt.NoFog)
            {
                Console.WriteLine("Removing fog...");
                env.EnableFog = false;
            }

            if (opt.MaxSpeedLargeShip != 100f)
            {
                Console.WriteLine("Setting maximum large ship speed to {0} m/s...", opt.MaxSpeedLargeShip);
                env.LargeShipMaxSpeed = opt.MaxSpeedLargeShip;
            }
            if (opt.MaxSpeedSmallShip != 100f)
            {
                Console.WriteLine("Setting maximum small ship speed to {0} m/s...", opt.MaxSpeedSmallShip);
                env.SmallShipMaxSpeed = opt.MaxSpeedSmallShip;
            }

            using (var wstrm = mod.WriteFile("Data/Environment.sbc"))
            {
                SaveEnv(wstrm, env);
            }

            Console.WriteLine("Saving mod to {0}...", Path.GetFullPath(opt.OutDir));
            (mod as DirectoryMod).CopyTo(opt.OutDir);

            if (opt.WaitForInput)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void SaveEnv(Stream stream, Environment env)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            using (var xmlw = XmlWriter.Create(stream, settings))
            {
                var envdefs = new SETweaks.Mods.DataBindings.Environment.EnvironmentDefinitions();
                envdefs.Environment = env;
                getEnvSerializer().Serialize(xmlw, envdefs);
            }
        }

        private static XmlSerializer getEnvSerializer()
        {
            return new XmlSerializer(typeof(SETweaks.Mods.DataBindings.Environment.EnvironmentDefinitions));
        }

        private static Environment LoadEnv(Stream stream)
        {
            using (var envstream = stream)
            {
                var envdefs = (SETweaks.Mods.DataBindings.Environment.EnvironmentDefinitions)getEnvSerializer().Deserialize(envstream);
                return envdefs.Environment;
            }
        }
    }
}
