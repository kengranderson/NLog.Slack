using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Slack
{
    public class SlackClient
    {
        public event Action<Exception> Error;

        public async Task SendAsync(string url, string data)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    await client.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }

        void OnError(Exception obj)
        {
            if (Error != null)
                Error(obj);
        }
    }
}
