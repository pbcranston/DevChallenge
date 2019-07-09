using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Interfaces
{
    /// <summary>
    /// Common properties for ListRequest models
    /// </summary>
    public interface IListRequestModel
    {
        /// <summary>
        /// How many items per page do you want?
        /// </summary>
        int ItemsPerPage { get; set; }

        /// <summary>
        /// Which page?
        /// </summary>
        int PageNumber { get; set; }

        /// <summary>
        /// Field to sort on
        /// </summary>
        string SortBy { get; set; }

        /// <summary>
        /// Should we sort in a descending order
        /// </summary>
        bool SortDesc { get; set; }
    }
}
