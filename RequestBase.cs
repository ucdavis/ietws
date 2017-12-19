using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ietws
{
    public abstract class RequestBase {
        private readonly IetClient client;

        protected string Url { get; set; }
        protected StringDictionary QueryItems { get; set; }

        public RequestBase(IetClient client)
        {
            this.client = client;
        }

        protected async Task<T> GetAsync<T>() {
            // TODO: build query string
            this.QueryItems.Add("key", client.Key);
            
            var result = await client.HttpProvider.GetAsync(client.BaseUrl + this.Url);

            result.EnsureSuccessStatusCode();

            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultContent);
        }

        protected async Task<HttpResponseMessage> GetAsync() {
            return await client.HttpProvider.GetAsync(this.client.BaseUrl);
        }
    }
}
