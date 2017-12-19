﻿using System;
using System.Net.Http;

namespace Ietws
{
    public class IetClient
    {
        public IetClient(string key, string baseUrl = "https://iet-ws.ucdavis.edu/api/")
        {
            // TODO: config setting
            Key = key;
            BaseUrl = baseUrl;

            HttpProvider = new HttpClient();
        }

        public ContactRequests Contacts => new ContactRequests(this);

        public string Key { get; private set; }
        public string BaseUrl { get; private set; }
        public HttpClient HttpProvider { get; private set; }
    }
}
