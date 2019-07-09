using Openwrks.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Generic
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemViewModel<T> : IViewModel<T>
        where T : class, new()
    {
        public T Data { get; set; }
        
        public ResponseViewModel Status { get; set; }
    }
}
