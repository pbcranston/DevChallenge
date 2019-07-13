using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Models.Interfaces;

namespace Openwrks.Business.Models.Models.User
{
    public class UserCreateModel : ICreateModel
    {
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid BankId { get; set; }
    }
}
