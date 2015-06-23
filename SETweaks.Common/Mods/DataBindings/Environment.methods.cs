/**
* Methods for messing with <Environment> stuff.
* *NOT* Automatically Generated
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
using System.Xml;
using System.IO;
using log4net;
using SETweak.Logging;

namespace SETweak.Mods.DataBindings
{
    public partial class Environment
    {
        static ILog log = LogManager.GetLogger(typeof(Environment));
        [Serializable, XmlRoot("Definitions")]
        public class EnvironmentDefinitions
        {
            // "@xmlns:xsd": "http://www.w3.org/2001/XMLSchema"
            // "@xmlns:xsi": "http://www.w3.org/2001/XMLSchema-instance"
            // "Environment": {"Id": {"TypeId": "EnvironmentDefinition", "SubtypeId": "Default"}, "SunDirection": {"@x": "0.339467347", "@y": "0.709795356", "@z": "-0.617213368"}, "EnvironmentTexture": "Textures\\BackgroundCube\\Final\\BrightEarth", "EnvironmentOrientation": {"@Pitch": "-61.1861954", "@Roll": "90.9057846", "@Yaw": "60.3955574"}, "EnableFog": "false", "FogNear": "100", "FogFar": "200", "FogMultiplier": "1", "FogBacklightMultiplier": "1", "FogColor": {"@x": "0", "@y": "0", "@z": "0"}, "SunDiffuse": {"@x": "0.784313738", "@y": "0.784313738", "@z": "0.784313738"}, "SunIntensity": "1", "SunSpecular": {"@x": "0.784313738", "@y": "0.784313738", "@z": "0.784313738"}, "BackLightDiffuse": {"@x": "0", "@y": "0", "@z": "0"}, "BackLightIntensity": "0", "AmbientColor": {"@x": "0.0141176477", "@y": "0.0141176477", "@z": "0.0141176477"}, "AmbientMultiplier": "1", "EnvironmentAmbientIntensity": "0.1", "BackgroundColor": {"@x": "1", "@y": "1", "@z": "1"}, "SunMaterial": "SunDisk", "SunSizeMultiplier": "200"}
            [XmlElement("Environment")]
            public Environment Environment { get; set; }

            [XmlElement("CubeBlocks")]
            public List<CubeBlock> CubeBlocks { get; set; }

            public static object Load(IMod mod, string p)
            {
                throw new NotImplementedException();
            }
        }

        public static XmlSerializer getEnvSerializer()
        {
            return new XmlSerializer(typeof(SETweak.Mods.DataBindings.Environment.EnvironmentDefinitions));
        }

        #region Loading
        public static Environment Load(IMod mod)
        {
            using(var stream = mod.ReadFile("Data/Environment.sbc"))
                return Load(string.Format("{0}:/Data/Environment.sbc", mod.ToString()), stream);
        }
        public static Environment Load(string filename)
        {
            var ser = new XmlSerializer(typeof(EnvironmentDefinitions));
            using (XmlReader rdr = XmlReader.Create(filename))
            {
                return ((EnvironmentDefinitions)ser.Deserialize(rdr)).Environment;
            }
        }

        public static Environment Load(string name, Stream stream)
        {
            using(log.BeginInfo(string.Format("Loading {0}...", name)))
                return ((SETweak.Mods.DataBindings.Environment.EnvironmentDefinitions)getEnvSerializer().Deserialize(stream)).Environment;
        }
        #endregion

        #region Saving
        public static void Save(Stream stream, Environment env)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            using (var xmlw = XmlWriter.Create(stream, settings))
            {
                var envdefs = new SETweak.Mods.DataBindings.Environment.EnvironmentDefinitions();
                envdefs.Environment = env;
                getEnvSerializer().Serialize(xmlw, envdefs);
            }
        }

        public void Save(string filename)
        {
            var ser = new XmlSerializer(typeof(EnvironmentDefinitions));
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            var def = new EnvironmentDefinitions();
            def.Environment = this;
            using (XmlWriter w = XmlWriter.Create(filename, settings))
            {
                ser.Serialize(w, def);
            }
        }
        #endregion
    }
}
