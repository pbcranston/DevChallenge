using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Data.Contracts;

namespace Openwrks.Data.Entities.Entities
{
    public class Bank : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public string Name { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
