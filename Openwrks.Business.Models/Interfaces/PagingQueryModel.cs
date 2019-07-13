using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Business.Models.Interfaces
{
    public class PagingQueryModel
    {
        public int ItemsPerPage { get; set; }
        public int PageNumber { get; set; }
        public string SortBy { get; set; }
        public bool SortDesc { get; set; }
    }
}
