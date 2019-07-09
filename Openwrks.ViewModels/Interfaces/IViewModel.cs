using Openwrks.ViewModels.Models.Response.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Interfaces
{
    /// <summary>
    /// A generic viewmodel interface
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IViewModel<TModel>
    {
        /// <summary>
        /// The data for the view model
        /// </summary>
        TModel Data { get; set; }

        /// <summary>
        /// The status and any error message
        /// </summary>
        ResponseViewModel Status { get; set; }
    }
}
