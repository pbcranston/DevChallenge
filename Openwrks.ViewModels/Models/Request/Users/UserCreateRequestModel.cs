using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.ViewModels.Interfaces;

namespace Openwrks.ViewModels.Models.Request.Users
{
    public class UserCreateRequestModel : ICreateRequestModel
    {
        public Guid? Id { get; set; }

        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid BankId { get; set; }
    }
}
