using Openwrks.Business.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Openwrks.Business.Models.Models.User
{
    public class UserListQueryModel : IQueryModel
    {
        public PagingQueryModel Paging { get; set; }
        public Guid BankId { get; set; }
    }
}
