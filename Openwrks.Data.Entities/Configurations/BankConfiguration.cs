using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Openwrks.Data.Entities.Entities;

namespace Openwrks.Data.Entities.Configurations
{
    public class BankConfiguration : BaseConfiguration<Bank>
    {
        public override void Configure(EntityTypeBuilder<Bank> builder)
        {
            base.Configure(builder);

            
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            
        }
    }
}
