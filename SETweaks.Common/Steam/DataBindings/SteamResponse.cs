using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;

namespace SETweaks.Steam.DataBindings
{
    public class SteamResponse<T>
    {
        [SerializeAs(Name = "response")]
        public T Response { get; set; }
    }
}
