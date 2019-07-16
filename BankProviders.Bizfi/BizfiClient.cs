using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BankProviders.Bizfi
{
    public sealed class BizfiClient
    {
        private static ApiV1BizfiClient instance = null;
        private static readonly object padlock = new object();

        public BizfiClient()
        {
        }

        public static ApiV1BizfiClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ApiV1BizfiClient("http://bizfibank-bizfitech.azurewebsites.net", new HttpClient());
                    }
                    return instance;
                }
            }
        }
    }
}
