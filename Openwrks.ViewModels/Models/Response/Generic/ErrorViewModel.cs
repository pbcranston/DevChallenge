using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Response.Generic
{
    public class ErrorViewModel
    {
        public ResponseViewModel Status { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
