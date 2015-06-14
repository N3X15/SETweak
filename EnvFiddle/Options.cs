using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clipr;
using System.ComponentModel;

namespace EnvFiddle
{
    public class Options
    {
        public Options()
        {
            MaxSpeedLargeShip = 100f;
            MaxSpeedSmallShip = 100f;
            WaitForInput = false;
            Presets = new List<string>();
        }
        [PositionalArgument(0, MetaVar = "IN", Description = "Path of the directory containing the original mod, OR the ID of the mod.")]
        public string Path { get; set; }

        [PositionalArgument(1, MetaVar = "OUT", Description = "Path of the directory to extract to.")]
        public string OutDir { get; set; }

        [NamedArgument('D', "dark-shadows", Action = ParseAction.StoreTrue)]
        [MutuallyExclusiveGroup("light levels")]
        public bool DarkShadows { get; set; }

        [NamedArgument('f', "no-fog", Action = ParseAction.StoreTrue)]
        public bool NoFog { get; set; }

        [NamedArgument('s', "smallship-max-speed")]
        public float MaxSpeedSmallShip { get; set; }

        [NamedArgument('S', "largeship-max-speed")]
        [DefaultValue(100f)]
        public float MaxSpeedLargeShip { get; set; }

        [NamedArgument("wait-for-input", Action = ParseAction.StoreTrue)]
        public bool WaitForInput { get; set; }

        [NamedArgument('p',"preset", Action = ParseAction.Append)]
        public List<string> Presets { get; set; }

    }
}
