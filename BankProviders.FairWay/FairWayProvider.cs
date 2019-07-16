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
        public ApiV1FairWayClient ApiClient
        {
            get { return FairWayClient.Instance; }
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
                    AccountNumber = account.Identifier.AccountNumber,
                    AccountName = account.Name,
                    SortCode = account.Identifier.SortCode
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
                var balance = await ApiClient.NumberBalanceGetAsync(accountNumber);
                if (balance == null)
                    return null;

                
                var accountDto = new BalanceDataModel()
                {
                    AvailableBalance = (balance.Amount ?? 0) * (double)balance.Type, // Value will evaluate to 1 for credit or -1 for debit
                    Balance = (balance.Amount ?? 0) * (double)balance.Type,
                    OverDraft = balance.Overdraft?.Amount ?? 0
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
                    if (transaction.BookedDate != null)
                        clearedDate = transaction.BookedDate.Value.DateTime;

                    transactionDtos.Add(new TransactionDataModel()
                    {
                        Amount = (transaction.Amount ?? 0) * (double)transaction.Type,
                        Date = clearedDate,
                        Description = transaction.TransactionInformation
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
