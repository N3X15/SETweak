using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using RestSharp;

namespace SETweaks.Steam
{
    public abstract class SteamAPIService
    {

        public abstract string ServiceID
        {
            get;
        }
        public abstract string ActionID
        {
            get;
        }

        public Dictionary<string, object> Arguments = new Dictionary<string, object>();
        public void SetParameter(string key, object value)
        {
            Arguments[key] = value;
        }
        public virtual void PreRequest()
        {
            return;
        }

    }

    public class SteamAPI
    {
        private const string BASE_URI = "http://api.steampowered.com";
        private const string API_VERSION = "v0001";

        private RestClient client;

        private string baseCacheDir;

        private static SteamAPI _instance;
        public static SteamAPI Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SteamAPI();
                return _instance;
            }
        }

        private SteamAPI()
        {
            client = new RestClient(BASE_URI);
            client.Proxy = null;
            client.AddDefaultParameter("format", "xml");
            client.AddHandler("text/plain", new RestSharp.Deserializers.XmlDeserializer());

            baseCacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SETweaks", "SteamAPICache");
            if (!Directory.Exists(baseCacheDir))
                Directory.CreateDirectory(baseCacheDir);

        }

        public IRestRequest genRequest(Method method, SteamAPIService swreq)
        {
            swreq.PreRequest();
            var req = new RestRequest(method);
            foreach (KeyValuePair<string, object> kvp in swreq.Arguments)
            {
                req.AddParameter(kvp.Key, kvp.Value);
            }
            req.Resource = string.Join("/", swreq.ServiceID, swreq.ActionID, API_VERSION);
            return req;
        }

        public XmlDocument response2xmldoc(IRestResponse response)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content);
            return doc;
        }

        private XmlDocument ExecuteAs(Method method, SteamAPIService req)
        {
            return response2xmldoc(client.Execute(genRequest(method, req)));
        }

        private T ExecuteAs<T>(Method method, SteamAPIService req) where T : new()
        {
            RestResponse<T> response = (RestResponse<T>)client.Execute<T>(genRequest(method, req));
            if (!string.IsNullOrEmpty(response.ErrorMessage))
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }

        public XmlDocument GET(SteamAPIService req)
        {
            return ExecuteAs(Method.GET, req);
        }

        public T GET<T>(SteamAPIService req) where T : new()
        {
            return ExecuteAs<T>(Method.GET, req);
        }

        public XmlDocument POST(SteamAPIService req)
        {
            return ExecuteAs(Method.POST, req);
        }

        public T POST<T>(SteamAPIService req) where T : new()
        {
            return ExecuteAs<T>(Method.POST, req);
        }
    }
}
