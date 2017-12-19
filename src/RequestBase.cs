using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
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
            this.QueryItems = new StringDictionary();
        }

        protected async Task<T> GetAsync<T>() {
            var uri = new StringBuilder();
            uri.Append(client.BaseUrl);
            uri.Append(this.Url);
            uri.AppendFormat("?key={0}", client.Key); // add in the key

            // add in any additional query string params
            foreach (string key in this.QueryItems.Keys) {
                uri.AppendFormat("&{0}={1}", key, this.QueryItems[key]);
            }
            
            var result = await client.HttpProvider.GetAsync(uri.ToString());

            result.EnsureSuccessStatusCode();

            var resultContent = await result.Content.ReadAsStringAsync();

            // TODO: remove
            System.Console.WriteLine(resultContent);

            return JsonConvert.DeserializeObject<T>(resultContent);
        }
    }
}
