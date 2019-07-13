using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Business.Models.Interfaces
{
    public interface IQueryModel
    {
        PagingQueryModel Paging { get; set; }
    }
}
