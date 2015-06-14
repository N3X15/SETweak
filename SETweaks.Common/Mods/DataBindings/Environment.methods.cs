using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace SETweaks.Mods.DataBindings
{
    public partial class Environment
    {
        [Serializable, XmlRoot("Definitions")]
        public class EnvironmentDefinitions
        {
            // "@xmlns:xsd": "http://www.w3.org/2001/XMLSchema"
            // "@xmlns:xsi": "http://www.w3.org/2001/XMLSchema-instance"
            // "Environment": {"Id": {"TypeId": "EnvironmentDefinition", "SubtypeId": "Default"}, "SunDirection": {"@x": "0.339467347", "@y": "0.709795356", "@z": "-0.617213368"}, "EnvironmentTexture": "Textures\\BackgroundCube\\Final\\BrightEarth", "EnvironmentOrientation": {"@Pitch": "-61.1861954", "@Roll": "90.9057846", "@Yaw": "60.3955574"}, "EnableFog": "false", "FogNear": "100", "FogFar": "200", "FogMultiplier": "1", "FogBacklightMultiplier": "1", "FogColor": {"@x": "0", "@y": "0", "@z": "0"}, "SunDiffuse": {"@x": "0.784313738", "@y": "0.784313738", "@z": "0.784313738"}, "SunIntensity": "1", "SunSpecular": {"@x": "0.784313738", "@y": "0.784313738", "@z": "0.784313738"}, "BackLightDiffuse": {"@x": "0", "@y": "0", "@z": "0"}, "BackLightIntensity": "0", "AmbientColor": {"@x": "0.0141176477", "@y": "0.0141176477", "@z": "0.0141176477"}, "AmbientMultiplier": "1", "EnvironmentAmbientIntensity": "0.1", "BackgroundColor": {"@x": "1", "@y": "1", "@z": "1"}, "SunMaterial": "SunDisk", "SunSizeMultiplier": "200"}
            [XmlElement("Environment")]
            public Environment Environment { get; set; }
        }

        public static Environment LoadFile(string filename)
        {
            var ser = new XmlSerializer(typeof(EnvironmentDefinitions));
            using (XmlReader rdr = XmlReader.Create(filename))
            {
                return ((EnvironmentDefinitions)ser.Deserialize(rdr)).Environment;
            }
        }

        public void SaveFile(string filename)
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
    }
}
