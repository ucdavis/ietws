using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ietws
{
    public class IetClient
    {
        public IetClient()
        {
            // TODO: config setting
            Key = "";
            BaseUrl = "https://iet-ws.ucdavis.edu/api/";

            HttpProvider = new HttpClient();
        }

        public ContactRequests Contact => new ContactRequests(this);

        public string Key { get; private set; }
        public string BaseUrl { get; private set; }
        public HttpClient HttpProvider { get; private set; }
    }

    public abstract class RequestBase {
        private readonly IetClient client;

        public RequestBase(IetClient client)
        {
            this.client = client;
        }

        protected async Task<T> GetAsync<T>(string url) {
            var result = await client.HttpProvider.GetAsync(url);

            result.EnsureSuccessStatusCode();

            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultContent);
        }

        protected async Task<HttpResponseMessage> GetAsync() {
            return await client.HttpProvider.GetAsync(this.client.BaseUrl);
        }
    }

    // IET always returns this base info and wraps the array of results in response data
    public class IetResult<T> {
        public string ResponseDetails { get; set; }
        public int ResponseStatus { get; set; }
        
        public ResponseData<T> ResponseData { get; set; }
    }

    public class ResponseData<T> { 
        public T[] Results { get; set; }
    }

    public class ContactResult {
        public string IamId { get; set; }
    }

    public class ContactResults : IetResult<ContactResult> {}

    public class ContactRequests : RequestBase {
        private readonly IetClient client;
        private string _url;

        public ContactRequests(IetClient client) : base(client) { }

        public async Task<ContactResults> Search(string q) {
            this._url = client.BaseUrl + "iam/people/contactinfo/search";
            return await this.GetAsync<ContactResults>(_url);
        }

    }
}
