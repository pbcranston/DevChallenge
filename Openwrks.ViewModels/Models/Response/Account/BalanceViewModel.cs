using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Account
{
    public class BalanceViewModel
    {
        public double Balance { get; set; }
        public double AvailableBalance { get; set; }

        public double OverDraft { get; set; }
    }
}
