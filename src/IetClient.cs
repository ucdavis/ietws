using System;
using System.Net.Http;

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
}
