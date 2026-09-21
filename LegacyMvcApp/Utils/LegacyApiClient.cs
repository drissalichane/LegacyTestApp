using System;
using RestSharp;

namespace LegacyMvcApp.Utils
{
    /// <summary>
    /// RestSharp 106 style client. The IRestResponse type, the
    /// RestRequest(resource, Method) constructor and the synchronous Execute
    /// overload were all removed in RestSharp 107+.
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

            var response = _client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Request failed: {response.StatusCode}");
            }

            return response.Content ?? string.Empty;
        }
    }
}
