using Openwrks.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Request.Generic
{
    public class UserListRequestModel : PagingParameterModel, IListRequestModel
    {
        public Guid BankId { get; set; }
    }
}
