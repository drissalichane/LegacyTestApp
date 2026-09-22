using System;
using RestSharp;

namespace LegacyMvcApp.Utils
{
    /// <summary>
    /// RestSharp usage updated for 107+ API (enum casing, RestResponse and nullable Content).
    /// </summary>
    public class LegacyApiClient
    {
        private readonly RestClient _client;

        public LegacyApiClient()
        {
            _client = new RestClient("https://example.com");
        }

        public string FetchReports()
        {
            var request = new RestRequest("api/reports", Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Request failed: {response.StatusCode}");
            }

            return response.Content ?? string.Empty;
        }
    }
}
