using Openwrks.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Generic
{
    /// <summary>
    /// 
    /// </summary>
    public class ListViewModel<T> : IListViewModel<T>
        where T : class, new()
    {
        
        public IEnumerable<T> Data { get; set; }

        public PagingViewModel Paging { get; set; }

        /// <inheritdoc/>
        public ResponseViewModel Status { get; set; }
    }
}
