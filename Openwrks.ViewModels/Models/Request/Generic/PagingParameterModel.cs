using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Openwrks.ViewModels.Models.Request.Generic
{
    /// <summary>
    /// 
    /// </summary>
    public class PagingParameterModel
    {
        public PagingParameterModel()
        {
            ItemsPerPage = 10;
            PageNumber = 1;
        }

        [DefaultValue(10)]
        public int ItemsPerPage { get; set; }

        [DefaultValue(1)]
        public int PageNumber { get; set; }

        public string SortBy { get; set; }

        public bool SortDesc { get; set; }
    }
}
