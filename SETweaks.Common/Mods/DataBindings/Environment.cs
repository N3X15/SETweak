using System;
using System.Xml.Serialization;

namespace SETweaks.Mods.DataBindings
{
    [Serializable]
    public partial class Environment
    {
        [XmlElement("Id", Order = 0)]
        public Id Id;

        [XmlElement("EnvironmentAmbientIntensity", IsNullable = true, Order = 1)]
        public Nullable<float> EnvironmentAmbientIntensity = 0.5f;

        [XmlElement("SunMaterial", IsNullable = true, Order = 2)]
        public string SunMaterial = "SunDisk";

        [XmlElement("FogColor", Order = 3)]
        public Vector3f FogColor;

        [XmlElement("SunSizeMultiplier", IsNullable = true, Order = 4)]
        public Nullable<float> SunSizeMultiplier = 200f;

        [XmlElement("FogBacklightMultiplier", Order = 5)]
        public float FogBacklightMultiplier;

        [XmlElement("BackLightDiffuse", IsNullable = true, Order = 6)]
        public Vector3f BackLightDiffuse = new Vector3f(0.784313738f, 0.784313738f, 0.784313738f);

        [XmlElement("BackLightIntensity", IsNullable = true, Order = 7)]
        public Nullable<float> BackLightIntensity = 0.239f;

        [XmlElement("FogDensity", Order = 8)]
        public float FogDensity;

        [XmlElement("SunIntensity", IsNullable = true, Order = 9)]
        public Nullable<float> SunIntensity = 1.456f;

        [XmlElement("BackgroundColor", IsNullable = true, Order = 10)]
        public Vector3f BackgroundColor = new Vector3f(1f, 1f, 1f);

        [XmlElement("EnableFog", Order = 11)]
        public bool EnableFog;

        [XmlElement("SunDiffuse", IsNullable = true, Order = 12)]
        public Vector3f SunDiffuse = new Vector3f(0.784313738f, 0.784313738f, 0.784313738f);

        [XmlElement("SunDirection", Order = 13)]
        public Vector3f SunDirection;

        [XmlElement("Enabled", IsNullable = true, Order = 14)]
        public Nullable<bool> Enabled = true;

        [XmlElement("LargeShipMaxAngularSpeed", IsNullable = true, Order = 15)]
        public Nullable<float> LargeShipMaxAngularSpeed = 18000f;

        [XmlElement("EnvironmentTexture", Order = 16)]
        public string EnvironmentTexture;

        [XmlElement("Icon", Order = 17)]
        public string Icon;

        [XmlElement("FogFar", Order = 18)]
        public float FogFar;

        [XmlElement("AmbientMultiplier", IsNullable = true, Order = 19)]
        public Nullable<float> AmbientMultiplier = 0.969f;

        [XmlElement("SmallShipMaxSpeed", IsNullable = true, Order = 20)]
        public Nullable<float> SmallShipMaxSpeed = 100f;

        [XmlElement("Description", Order = 21)]
        public string Description;

        [XmlElement("Public", IsNullable = true, Order = 22)]
        public Nullable<bool> Public = true;

        [XmlElement("AmbientColor", IsNullable = true, Order = 23)]
        public Vector3f AmbientColor = new Vector3f(0.141176477f, 0.141176477f, 0.141176477f);

        [XmlElement("SmallShipMaxAngularSpeed", IsNullable = true, Order = 24)]
        public Nullable<float> SmallShipMaxAngularSpeed = 36000f;

        [XmlElement("LargeShipMaxSpeed", IsNullable = true, Order = 25)]
        public Nullable<float> LargeShipMaxSpeed = 100f;

        [XmlElement("EnvironmentOrientation", Order = 26)]
        public EulerRot EnvironmentOrientation;

        [XmlElement("DisplayName", Order = 27)]
        public string DisplayName;

        [XmlElement("SunSpecular", IsNullable = true, Order = 28)]
        public Vector3f SunSpecular = new Vector3f(0.784313738f, 0.784313738f, 0.784313738f);

        [XmlElement("FogNear", Order = 29)]
        public float FogNear;

        [XmlElement("FogMultiplier", Order = 30)]
        public float FogMultiplier;

    }
}
