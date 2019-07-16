using BankProviders.Contracts;
using Openwrks.Business.Models.Models.Account;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankProviders.Bizfi
{
    public class BizfiProvider : IBankProvider
    {
        public ApiV1AccountsByAccountClient ApiClient
        {
            get { return BizfiClient.Instance; }
        }
        

        public async Task<AccountDataModel> GetAccountAsync(string accountNumber)
        {
            try
            {
                var account = await ApiClient.NumberGetAsync(accountNumber);
                if (account == null)
                    return null;

                var accountDto = new AccountDataModel()
                {
                    AccountNumber = account.Account_number,
                    AccountName = account.Account_name,
                    SortCode = account.Sort_code
                };

                return accountDto;
            }
            catch (Exception ex)
            {
                // Log this error to serilog

                throw;
            }
        }

        public async Task<BalanceDataModel> GetBalanceAsync(string accountNumber)
        {
            try
            {
                var account = await ApiClient.NumberGetAsync(accountNumber);
                if (account == null)
                    return null;

                var accountDto = new BalanceDataModel()
                {
                    AvailableBalance = account.Available_balance ?? 0,
                    Balance = account.Balance ?? 0,
                    OverDraft = account.Overdraft ?? 0
                };

                return accountDto;
            }
            catch (Exception ex)
            {
                // Log this error to serilog

                throw;
            }
        }

        public async Task<List<TransactionDataModel>> GetTransactionsAsync(string accountNumber)
        {
            try
            {
                var transactions = await ApiClient.NumberTransactionsGetAsync(accountNumber);
                if (transactions == null)
                    return null;

                var transactionDtos = new List<TransactionDataModel>();

                foreach (var transaction in transactions)
                {

                    var clearedDate = DateTime.MinValue;
                    if (transaction.Cleared_date != null)
                        clearedDate = transaction.Cleared_date.Value.DateTime;

                    transactionDtos.Add(new TransactionDataModel()
                    {
                        Amount = transaction.Amount ?? 0,
                        Date = clearedDate,
                        Description = transaction.Merchant
                    });
                }

                return transactionDtos;
            }
            catch (Exception ex)
            {
                // Log this error to serilog

                throw;
            }
        }
    }
}
