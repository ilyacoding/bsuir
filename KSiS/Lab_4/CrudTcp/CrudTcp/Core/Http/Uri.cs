using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Core.Http
{
    public class Uri
    {
        public string Controller { get; set; }
        public List<string> UrlParams { get; set; }
        public Dictionary<string, string> UriDictionary { get; set; }

        public Uri(List<string> urlParams, string controller, Dictionary<string, string> uriDictionary)
        {
            UrlParams = urlParams;
            Controller = controller;
            UriDictionary = uriDictionary;
        }

        public static Uri Parse(string uri)
        {
            var uriDictionary = new Dictionary<string, string>();
            uri = uri.Trim('/', '\\');

            var uriParts = uri.Split('?');
            var url = uriParts[0].Split('/').ToList();

            if (uriParts.Length > 2 || url.Count == 0) throw new Exception("404");

            var controller = url[0];

            url.Remove(controller);
            
            if (uriParts.Length != 2) return new Uri(url, controller, uriDictionary);

            var parameters = uriParts[1].Split('&');
            uriDictionary = parameters.Select(element => element.Split('=')).Where(keyValue => keyValue.Length == 2).ToDictionary(keyValue => keyValue[0].Trim(), keyValue => keyValue[1].Trim());

            return new Uri(url, controller, uriDictionary);
        }
    }
}
