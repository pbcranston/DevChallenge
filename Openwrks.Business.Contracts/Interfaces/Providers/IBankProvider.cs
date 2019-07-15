using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Openwrks.Business.Models.Models.Account;

namespace Openwrks.Business.Contracts.Interfaces.Providers
{
    public interface IBankProvider
    {
        Task<AccountDataModel> GetAccountAsync(string accountNumber);

        Task<BalanceDataModel> GetBalance(string accountNumber);

        Task<List<TransactionDataModel>> GetTransactions(string accountNumber);
    }
}
