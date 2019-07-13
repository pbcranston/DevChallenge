using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Models.Interfaces;

namespace Openwrks.Business.Models.Models.User
{
    public class UserDataModel : IDataModel
    {
        public Guid Id { get; set; }
    }
}
