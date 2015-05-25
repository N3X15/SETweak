using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

namespace SETweaks.Mods.DataBindings
{
    [Serializable]
    public class Environment
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
        [XmlElement("FogMultiplier")]
        public float FogMultiplier;

        [XmlElement("FogNear")]
        public float FogNear;

        [XmlElement("SunSpecular", IsNullable = true)]
        public Vector3f SunSpecular = new Vector3f(0.784313738f, 0.784313738f, 0.784313738f);

        [XmlElement("EnvironmentOrientation")]
        public EulerRot EnvironmentOrientation;

        [XmlElement("LargeShipMaxSpeed", IsNullable = true)]
        public Nullable<float> LargeShipMaxSpeed = 100f;

        [XmlElement("SmallShipMaxAngularSpeed", IsNullable = true)]
        public Nullable<float> SmallShipMaxAngularSpeed = 36000f;

        [XmlElement("AmbientColor", IsNullable = true)]
        public Vector3f AmbientColor = new Vector3f(0.141176477f, 0.141176477f, 0.141176477f);

        [XmlElement("SmallShipMaxSpeed", IsNullable = true)]
        public Nullable<float> SmallShipMaxSpeed = 100f;

        [XmlElement("AmbientMultiplier", IsNullable = true)]
        public Nullable<float> AmbientMultiplier = 0.969f;

        [XmlElement("FogFar")]
        public float FogFar;

        [XmlElement("EnvironmentAmbientIntensity", IsNullable = true)]
        public Nullable<float> EnvironmentAmbientIntensity = 0.5f;

        [XmlElement("LargeShipMaxAngularSpeed", IsNullable = true)]
        public Nullable<float> LargeShipMaxAngularSpeed = 36000f;

        [XmlElement("SunDirection")]
        public Vector3f SunDirection;

        [XmlElement("SunDiffuse", IsNullable = true)]
        public Vector3f SunDiffuse = new Vector3f(0.784313738f, 0.784313738f, 0.784313738f);

        [XmlElement("EnableFog")]
        public bool EnableFog;

        [XmlElement("BackgroundColor", IsNullable = true)]
        public Vector3f BackgroundColor = new Vector3f(1f, 1f, 1f);

        [XmlElement("SunIntensity", IsNullable = true)]
        public Nullable<float> SunIntensity = 1.456f;

        [XmlElement("FogDensity")]
        public float FogDensity;

        [XmlElement("BackLightIntensity", IsNullable = true)]
        public Nullable<float> BackLightIntensity = 0.239f;

        [XmlElement("BackLightDiffuse", IsNullable = true)]
        public Vector3f BackLightDiffuse = new Vector3f(0.784313738f, 0.784313738f, 0.784313738f);

        [XmlElement("FogBacklightMultiplier")]
        public float FogBacklightMultiplier;

        [XmlElement("Id")]
        public Id Id;

        [XmlElement("FogColor")]
        public Vector3f FogColor;

        [XmlElement("SunMaterial", IsNullable = true)]
        public string SunMaterial = "SunDisk";

        [XmlElement("SunSizeMultiplier", IsNullable = true)]
        public Nullable<float> SunSizeMultiplier = 200f;

    }
}
