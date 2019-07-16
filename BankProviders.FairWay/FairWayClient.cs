using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BankProviders.FairWay
{
    public sealed class FairWayClient
    {
        private static ApiV1FairWayClient instance = null;
        private static readonly object padlock = new object();

        public FairWayClient()
        {
        }

        public static ApiV1FairWayClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ApiV1FairWayClient("http://fairwaybank-bizfitech.azurewebsites.net", new HttpClient());
                    }
                    return instance;
                }
            }
        }
    }
}
