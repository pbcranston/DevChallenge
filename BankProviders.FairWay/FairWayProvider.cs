using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BankProviders.Contracts;
using Openwrks.Business.Models.Models.Account;

namespace BankProviders.FairWay
{
    public class FairWayProvider : IBankProvider
    {
        public async Task<AccountDataModel> GetAccountAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<BalanceDataModel> GetBalanceAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransactionDataModel>> GetTransactionsAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
