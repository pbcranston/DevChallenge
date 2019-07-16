using Openwrks.Business.Models.Models.Bank;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Business.Contracts.Interfaces
{
    public interface IBankService : IBaseService<Bank, BankDataModel, BankCreateModel, BankListQueryModel>
    {
    }
}
