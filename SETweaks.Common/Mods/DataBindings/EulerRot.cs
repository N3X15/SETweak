using System;
using System.Xml.Serialization;

namespace SETweaks.Mods.DataBindings
{
    [Serializable]
    public class EulerRot
    {
        [XmlAttribute]
        public double Yaw { get; set; }
        [XmlAttribute]
        public double Pitch { get; set; }
        [XmlAttribute]
        public double Roll { get; set; }
    }
}
