using Openwrks.ViewModels.Models.Response.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IListViewModel<TModel>
    {
        /// <summary>
        /// The data for the view model
        /// </summary>
        IEnumerable<TModel> Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        PagingViewModel Paging { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ResponseViewModel Status { get; set; }
    }
}