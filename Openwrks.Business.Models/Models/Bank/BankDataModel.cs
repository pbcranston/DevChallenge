using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Models.Interfaces;

namespace Openwrks.Business.Models.Models.Bank
{
    public class BankDataModel : IDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
