/**
* BLURB GOES HERE.
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
