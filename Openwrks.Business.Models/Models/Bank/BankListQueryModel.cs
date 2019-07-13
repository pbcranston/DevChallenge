using Openwrks.Business.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Business.Models.Models.Bank
{
    public class BankListQueryModel : IQueryModel
    {
        public PagingQueryModel Paging { get; set; }
    }
}
