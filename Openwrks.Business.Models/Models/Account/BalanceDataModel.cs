using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Business.Models.Models.Account
{
    public class BalanceDataModel
    {
        public double Balance { get; set; }
        public double AvailableBalance { get; set; }

        public double OverDraft { get; set; }
    }
}
