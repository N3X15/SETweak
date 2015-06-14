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
