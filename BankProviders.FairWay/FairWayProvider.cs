using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Contracts.Interfaces.Providers;
using Openwrks.Business.Models.Models.Account;

namespace BankProviders.FairWay
{
    public class FairWayProvider : IBankProvider
    {
        public AccountDataModel GetAccountAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public BalanceDataModel GetBalance(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<TransactionDataModel> GetTransactions(string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
