using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BankProviders.Bizfi
{
    public sealed class BizfiClient
    {
        private static ApiV1AccountsByAccountClient instance = null;
        private static readonly object padlock = new object();

        public BizfiClient()
        {
        }

        public static ApiV1AccountsByAccountClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ApiV1AccountsByAccountClient("http://bizfibank-bizfitech.azurewebsites.net", new HttpClient());
                    }
                    return instance;
                }
            }
        }
    }
}
