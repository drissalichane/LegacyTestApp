using System;
using System.Net;
using System.Net.Mail;

namespace LegacyMvcApp.Utils
{
    public class LegacyNetwork
    {
        public void SendEmail()
        {
            // SmtpClient is obsolete
#pragma warning disable SYSLIB0014 // WebRequest and SmtpClient are obsolete
            var client = new SmtpClient("smtp.example.com");
            client.Send("from@example.com", "to@example.com", "Test", "Test body");
        }

        public string FetchData()
        {
            // WebRequest is obsolete
            WebRequest request = WebRequest.Create("https://example.com");
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
#pragma warning restore SYSLIB0014
        }
    }
}
