using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NLogTargetsLoggly
{
    public sealed class LogglyClient
    {
        private readonly string _token;

        public LogglyClient(string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            _token = token;
        }

        public void Log(string tag, LogglyEvent logglyEvent)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "http://logs-01.loggly.com/inputs/" + _token + "/tag/" + tag + "/")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(logglyEvent), Encoding.UTF8, "application/json")
                }).Result;
            }
        }

        public async Task LogAsync(string tag, LogglyEvent logglyEvent)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "http://logs-01.loggly.com/inputs/" + _token + "/tag/" + tag + "/")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(logglyEvent), Encoding.UTF8, "application/json")
                });
            }
        }
    }
}
