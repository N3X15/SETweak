using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clipr;

namespace EnvFiddle
{
    public class Options
    {
        [PositionalArgument(0, MetaVar = "IN", Description = "Path of the directory containing the original mod, OR the ID of the mod.")]
        public string Path { get; set; }

        [PositionalArgument(1, MetaVar = "OUT", Description = "Path of the directory to extract to.")]
        public string OutDir { get; set; }

        [NamedArgument('D', "dark-shadows", Action = ParseAction.StoreTrue)]
        [MutuallyExclusiveGroup("light levels")]
        public bool DarkShadows { get; set; }

        [NamedArgument('s', "smallship-max-speed")]
        public float MaxSpeedSmallShip { get; set; }

        [NamedArgument('S', "largeship-max-speed")]
        public float MaxSpeedLargeShip { get; set; }

    }
}
