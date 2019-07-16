using Openwrks.Business.Models.Models.Bank;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Contracts.Interfaces;
using Openwrks.Data.Contracts;
using AutoMapper;

namespace Openwrks.Business.Services
{
    public class BankService : BaseService<Bank, BankDataModel, BankCreateModel, BankListQueryModel>, IBankService
    {
        public BankService(IMapper mapper,
            IRepository<Bank> repository) : base(mapper, repository)
        {
        }
    }
}
