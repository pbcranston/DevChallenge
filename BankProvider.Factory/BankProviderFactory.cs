using BankProviders.Bizfi;
using System;
using System.Collections.Generic;
using System.Text;
using BankProviders.FairWay;
using BankProviders;
using BankProviders.Contracts;

namespace BankProvider.Factory
{
    public static class BankProviderFactory
    {
        private static BizfiProvider _bizfiProvider;
        private static FairWayProvider _fairWayProvider;

        public static IBankProvider GetBankProvider(string bank)
        {
            switch (bank)
            {
                case "BizfiBank":
                    if(_bizfiProvider == null)
                        _bizfiProvider = new BizfiProvider();
                    return _bizfiProvider;
                case "FairWayBank":
                    if(_fairWayProvider == null)
                       _fairWayProvider = new FairWayProvider();
                    return _fairWayProvider;
                default:
                    throw new NotImplementedException($"No provider exists for bank: {bank}.");
            }
        }
    }
}
