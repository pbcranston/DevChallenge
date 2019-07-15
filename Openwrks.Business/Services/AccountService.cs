using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Openwrks.Business.Contracts.Interfaces;
using Openwrks.Business.Contracts.Interfaces.Providers;
using Openwrks.Business.Models.Models.Account;

namespace Openwrks.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        private readonly IBankProvider _bizfiProvider;
        private readonly IBankProvider _fairWayProvider;

        public AccountService(IUserService userService,
            IBankProvider bizfiProvider,
            IBankProvider fairWayProvider)
        {
            _userService = userService;
            _bizfiProvider = bizfiProvider;
            _fairWayProvider = fairWayProvider;
        }

        public async Task<AccountDataModel> GetAccountAsync(string accountNumber)
        {
            var user = await _userService.GetAsync(accountNumber);

            switch (user.BankName)
            {
                case "BizfiBank":
                    return await _bizfiProvider.GetAccountAsync(accountNumber);
                case "FairWayBank":
                    return await _fairWayProvider.GetAccountAsync(accountNumber);
                default:
                    return null;
            }
        }

        public async Task<BalanceDataModel> GetBalanceAsync(string accountNumber)
        {
            var user = await _userService.GetAsync(accountNumber);

            switch (user.BankName)
            {
                case "BizfiBank":
                    return await _bizfiProvider.GetBalance(accountNumber);
                case "FairWayBank":
                    return await _fairWayProvider.GetBalance(accountNumber);
                default:
                    return null;
            }
        }

        public async Task<List<TransactionDataModel>> GetTransactionsAsync(string accountNumber)
        {
            var user = await _userService.GetAsync(accountNumber);

            switch (user.BankName)
            {
                case "BizfiBank":
                    return await _bizfiProvider.GetTransactions(accountNumber);
                case "FairWayBank":
                    return await _fairWayProvider.GetTransactions(accountNumber);
                default:
                    return null;
            }
        }
    }
}
