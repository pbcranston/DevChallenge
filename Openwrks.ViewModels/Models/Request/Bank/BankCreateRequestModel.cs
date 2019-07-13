using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.ViewModels.Interfaces;

namespace Openwrks.ViewModels.Models.Request.Bank
{
    public class BankCreateRequestModel : ICreateRequestModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
