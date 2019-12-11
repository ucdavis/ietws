using System;
using System.Net.Http;
using ietws.PPSDepartment;

namespace Ietws
{
    public class IetClient
    {
        public IetClient(string key, string baseUrl = "https://iet-ws.ucdavis.edu/api/")
        {
            Key = key;
            BaseUrl = baseUrl;

            HttpProvider = new HttpClient();
        }

        public IetClient(HttpClient client, string key, string baseUrl = "https://iet-ws.ucdavis.edu/api/")
        {
            Key = key;
            BaseUrl = baseUrl;

            HttpProvider = client;
        }

        public ContactRequests Contacts => new ContactRequests(this);

        public PeopleRequests People => new PeopleRequests(this);

        public KerberosRequests Kerberos => new KerberosRequests(this);

        public PPSAssociationsRequests PPSAssociations => new PPSAssociationsRequests(this);

        public PPSDepartmentRequest PpsDepartment => new PPSDepartmentRequest(this);

        public string Key { get; private set; }
        public string BaseUrl { get; private set; }
        public HttpClient HttpProvider { get; private set; }
    }
}
