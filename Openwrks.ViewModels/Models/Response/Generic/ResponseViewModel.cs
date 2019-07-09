using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Generic
{
    public class ResponseViewModel
    {
        /// <summary>
        /// The response status code.
        /// </summary>
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// The response message.
        /// </summary>
        public string Message { get; set; }
    }
}
