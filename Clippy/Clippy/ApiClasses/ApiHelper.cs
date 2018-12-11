using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Clippy
{
    /// <summary>
    /// Class to help manage the HttpClient and provide the basis for API access.
    /// Static to prevent multiple different instances of HttpClients, which can
    /// cause various exceptions
    /// Created by Keola Dunn
    /// </summary>
    public static class ApiHelper
    {
        // Client called and used throughout the app
        public static HttpClient ApiClient { get; set; } = null;

        // Base URI for all Clippy application API calls
        private static readonly string Uri = "http://54.162.248.95:4000";

        // Initiates the client to specified URI and API request settings
        public static void InitializeClient()
        {
                ApiClient = new HttpClient();
                ApiClient.BaseAddress = new Uri(Uri);
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
