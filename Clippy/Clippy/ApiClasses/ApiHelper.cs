using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace Clippy
{
    /// <summary>
    /// Class to help manage the HttpClient and provide the basis for API access
    /// </summary>
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = null;

        private static readonly string Uri = "http://54.162.248.95:4000";

        public static void InitializeClient()
        {
                ApiClient = new HttpClient();
                ApiClient.BaseAddress = new Uri(Uri);
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
