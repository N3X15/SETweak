using System;
using System.Collections.Generic;
using RestSharp.Serializers;
using System.Xml.Serialization;

namespace SETweaks.Mods.DataBindings
{
    [Serializable]
    public class Id
    {
        // "TypeId": "EnvironmentDefinition"
        [XmlElement("TypeId")]
        public string TypeId { get; set; }

        // "SubtypeId": "Default"
        [XmlElement("SubtypeId")]
        public string SubtypeId { get; set; }

    }
}
