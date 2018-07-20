using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace RestAPI.PasteAPI
{
    public static class PasteApiClient
    {
        private static string domain = WebConfigurationManager.AppSettings["Domain"];
        private static string baseApiUrl => domain + "/api/";
        private static string baseRawUrl => domain + "/raw/";

        private static string key = WebConfigurationManager.AppSettings["PasteKey"];

        /// <summary>
        /// Gets raw paste by identifier
        /// </summary>
        /// <param name="Identifier">Should be paste identitfier</param>
        /// <returns>Returns past api response</returns>
        public static IRestResponse GetRawPaste(string Identifier)
        {
            var client = new RestClient(baseRawUrl + Identifier);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}