using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Generic
{
    public class PagingViewModel
    {
        /// <summary>
        /// How many items are there that match this request
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// How many items returned per page
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// What was the requested page?
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
