﻿/**
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
using System.Xml.Serialization;

namespace SETweak.Mods.DataBindings
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

        public override string ToString()
        {
            return string.Format("{{Yaw: {0}, Roll: {1}, Pitch: {2}}}", Yaw, Pitch, Roll);
        }

        public override bool Equals(object other)
        {
            if (other is EulerRot)
            {
                var otherV = (EulerRot)other;
                return this.Yaw == otherV.Yaw && this.Pitch == otherV.Pitch && this.Roll == otherV.Roll;
            }
            else
                return false;
        }
    }
}
