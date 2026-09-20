using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace LegacyWebApi.Services
{
    /// <summary>
    /// Legacy reporting path: pulls rows with a hand-rolled SqlClient call and
    /// serialises them with Newtonsoft rather than System.Text.Json.
    /// </summary>
    public class LegacyReportService
    {
        private readonly string _connectionString;

        public LegacyReportService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string BuildReport()
        {
            var rows = new List<Dictionary<string, object>>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT Id, Name FROM Reports", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rows.Add(new Dictionary<string, object>
                            {
                                ["Id"] = reader.GetInt32(0),
                                ["Name"] = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            // Newtonsoft-specific settings that have no System.Text.Json equivalent
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(rows, settings);
        }

        public T? Deserialize<T>(string payload)
        {
            return JsonConvert.DeserializeObject<T>(payload);
        }
    }
}
