using CryptoTrackerServiceBus.Exception;
using CryptoTrackerServiceBus.Interfaces.External;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrackerServiceBus.Externals
{
    class API : IAPI
    {
        private readonly string host;
        private readonly HttpClient client;

        public API(string host)
        {
            this.host = host;
            client = new HttpClient
            {
                BaseAddress = new Uri(host)
            };
        }

        public async Task AggregateExternalSources()
        {
            var data = await client.PostAsync("/agregate", null);
            if (!data.IsSuccessStatusCode) {
                throw new TaskFailedException("Api response fail. Please, check API logs");
            }
        }
    }
}
