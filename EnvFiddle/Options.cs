/**
* Clipr command-line arg definitions.
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
