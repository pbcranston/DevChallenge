using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.ViewModels.Models.Request.Users
{
    public class UserCreateRequestModel
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
