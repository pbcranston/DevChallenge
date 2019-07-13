using Openwrks.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Data.Entities.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
