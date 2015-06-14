/**
* Class for generating EnvFiddle arguments.
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

namespace EnvFiddle.GUI
{
    public class EnvFiddleOptions
    {
        public string Path ="";
        public string OutDir = "";
        public bool DarkShadows = false;
        public float MaxSpeedSmallShip = 100f;
        public float MaxSpeedLargeShip = 100f;

        public override string ToString()
        {
            var sb = new List<string>();
            if (DarkShadows)
                sb.Add("-D");
            if (MaxSpeedSmallShip!=100f) {
                sb.Add("-s");
                sb.Add(MaxSpeedSmallShip.ToString());
            }
            if (MaxSpeedLargeShip != 100f){
                sb.Add("-S");
                sb.Add(MaxSpeedLargeShip.ToString());
            }
            sb.Add("--wait-for-input");
            sb.Add(string.Format("\"{0}\"", Path));
            sb.Add(string.Format("\"{0}\"", OutDir));
            return string.Join(" ", sb);
        }
    }
}
