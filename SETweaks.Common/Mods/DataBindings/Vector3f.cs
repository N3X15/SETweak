using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SETweaks.Mods.DataBindings
{
    [Serializable]
    public class Vector3f
    {
        public Vector3f() { }

        public Vector3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        [XmlAttribute]
        public double x { get; set; }

        [XmlAttribute]
        public double y { get; set; }

        [XmlAttribute]
        public double z { get; set; }

        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}>", x, y, z);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^
                   y.GetHashCode() ^
                   z.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if(other is Vector3f) {
                var otherV = (Vector3f)other;
                return this.x == otherV.x && this.y == otherV.y && this.z == otherV.z;
            } else
                return false;
        }
    }
}
