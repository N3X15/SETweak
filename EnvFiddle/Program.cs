/**
* Main program logic.
* 
* Copyright (c) 2015 Rob "N3X15" Nelson <nexisentertainment@gmail.com>
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clipr;
using SETweak.Mods;
using System.IO;
using System.Xml.Serialization;
using Environment = SETweak.Mods.DataBindings.Environment;
using System.Reflection;
using System.Xml;
using SETweak.Logging;
using log4net;

namespace EnvFiddle
{
    class Program
    {

        static List<BaseFixer> Fixers = new List<BaseFixer>();
        static ILog log = LogManager.GetLogger(typeof(Program));

        static void CopyIfNotNull(Environment a, Environment b, Environment defaults, FieldInfo field)
        {
            object value = field.GetValue(b);
            object current = field.GetValue(a);
            object defaultValue = field.GetValue(defaults);
            using (log.BeginDebug("{0}:", field.Name))
            {
                log.DebugFormat("default: {0}", defaultValue);
                log.DebugFormat("a: {0}", current);
                log.DebugFormat("b: {0}", value);
                if (value == null || current.Equals(defaultValue))
                    return;
                field.SetValue(a, value);
                log.InfoFormat("Set {0} to {1}.", field.Name, value);
            }
        }

        static void EnvMerge(Environment victim, Environment newvalues)
        {
            var defaults = new Environment();
            foreach (var finfo in typeof(Environment).GetFields())
            {
                CopyIfNotNull(victim, newvalues, defaults, finfo);
            }
        }

        static string BinDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        static void MergePreset(Environment env, string presetName)
        {
            using (log.BeginInfo(string.Format("Merging preset {0}...", presetName)))
            {
                presetName = Path.Combine(BinDir(), "Presets", presetName);
                Environment p_env;
                using (var stream = File.OpenRead(presetName))
                {
                    p_env = Environment.Load(presetName, stream);
                }
                EnvMerge(env, p_env);
            }
        }

        static void Main(string[] args)
        {
            LogIndent.Configure();
            var opt = CliParser.Parse<Options>(args);

            foreach (var type in Assembly.GetCallingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(BaseFixer)))
                {
                    Fixers.Add((BaseFixer)Activator.CreateInstance(type));
                }
            }

            IMod mod = Mod.LocateMod(opt.Path, opt.Clobber);

            SETweak.Mods.DataBindings.Environment env = Environment.Load(mod);
            if (env == null)
            {
                throw new NullReferenceException("Env is null.  Did something go wrong during load?");
            }

            if (opt.Presets != null && opt.Presets.Count > 0)
            {
                foreach (var presetName in opt.Presets)
                {
                    MergePreset(env, presetName);
                }
            }

            if (opt.DarkShadows)
            {
                MergePreset(env, "Special/DarkShadows.xml");
            }

            if (opt.NoFog)
            {
                log.Info("Removing fog...");
                env.EnableFog = false;
                env.FogDensity = 0;
            }

            if (opt.MaxSpeedLargeShip != 100f)
            {
                log.InfoFormat("Setting maximum large ship speed to {0} m/s...", opt.MaxSpeedLargeShip);
                env.LargeShipMaxSpeed = opt.MaxSpeedLargeShip;
            }
            if (opt.MaxSpeedSmallShip != 100f)
            {
                log.InfoFormat("Setting maximum small ship speed to {0} m/s...", opt.MaxSpeedSmallShip);
                env.SmallShipMaxSpeed = opt.MaxSpeedSmallShip;
            }

            using (log.BeginInfo("Checking for mistakes..."))
            {
                foreach (var fix in Fixers)
                {
                    fix.Fix(env);
                }
            }

            using (log.BeginInfo(string.Format("Saving mod to {0}...", Path.GetFullPath(opt.OutDir))))
            {
                (mod as DirectoryMod).CopyTo(opt.OutDir);

                DirectoryMod newmod = new DirectoryMod(opt.OutDir);
                using (var wstrm = newmod.WriteFile("Data/Environment.sbc"))
                {
                    Environment.Save(wstrm, env);
                }
            }

            if (opt.WaitForInput)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
