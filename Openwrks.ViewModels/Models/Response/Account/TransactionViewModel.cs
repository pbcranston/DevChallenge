using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Account
{
    public class TransactionViewModel
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
