using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Openwrks.Business.Contracts.Interfaces;
using AutoMapper;
using Openwrks.ViewModels.Models.Response.Account;
using Serilog;

namespace Openwrks.API.Controllers.v1
{
    [Route("api/account/")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IMapper mapper, ILogger log, IAccountService accountService) : base(mapper, log)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountNumber}", Name = "GetAccount")]
        [Produces("application/json", Type = typeof(AccountViewModel))]
        public async Task<IActionResult> GetAccount(string accountNumber)
        {
            var account = await _accountService.GetAccountAsync(accountNumber);

            var accountVm = Mapper.Map<AccountViewModel>(account);

            return await GetItemViewModel(accountVm);
        }


        [HttpGet("{accountNumber}/balance", Name = "GetBalance")]
        [Produces("application/json", Type = typeof(BalanceViewModel))]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            var balance = await _accountService.GetBalanceAsync(accountNumber);

            var balanceVm = Mapper.Map<BalanceViewModel>(balance);

            return await GetItemViewModel(balanceVm);
        }

        [HttpGet("{accountNumber}/transactions", Name = "GetTransactions")]
        [Produces("application/json", Type = typeof(List<TransactionViewModel>))]
        public async Task<IActionResult> GetTransactions(string accountNumber)
        {
            var transactions = await _accountService.GetTransactionsAsync(accountNumber);

            var transactionsVm = Mapper.Map<List<TransactionViewModel>>(transactions);

            return await GetItemViewModel(transactionsVm);
        }
    }
}
