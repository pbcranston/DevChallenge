using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Data.Contracts
{
    public interface IEntity : IBasicEntity
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
