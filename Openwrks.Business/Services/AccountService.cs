using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BankProvider.Factory;
using Openwrks.Business.Contracts.Interfaces;
using Openwrks.Business.Models.Models.Account;

namespace Openwrks.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AccountDataModel> GetAccountAsync(string accountNumber)
        {
            var user = await _userService.GetAsync(accountNumber);

            var bankProvider = BankProviderFactory.GetBankProvider(user.BankName);

            return await bankProvider.GetAccountAsync(accountNumber);
        }

        public async Task<BalanceDataModel> GetBalanceAsync(string accountNumber)
        {
            var user = await _userService.GetAsync(accountNumber);

            var bankProvider = BankProviderFactory.GetBankProvider(user.BankName);

            return await bankProvider.GetBalanceAsync(accountNumber);
        }

        public async Task<List<TransactionDataModel>> GetTransactionsAsync(string accountNumber)
        {
            var user = await _userService.GetAsync(accountNumber);

            var bankProvider = BankProviderFactory.GetBankProvider(user.BankName);

            return await bankProvider.GetTransactionsAsync(accountNumber);
        }
    }
}
