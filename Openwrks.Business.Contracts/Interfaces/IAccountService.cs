using Openwrks.Business.Models.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Openwrks.Business.Contracts.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDataModel> GetAccountAsync(string accountNumber);

        Task<BalanceDataModel> GetBalanceAsync(string accountNumber);

        Task<List<TransactionDataModel>> GetTransactionsAsync(string accountNumber);
    }
}
