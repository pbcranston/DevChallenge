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


            builder.HasData(
                new Bank
                {
                    Id = Guid.Parse("222EA055-AFAF-47D2-8CFE-260A0BE88658"),
                    Name = "BizfiBank",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Bank
                {
                    Id = Guid.Parse("8D4B7236-94C4-4949-A924-9B4E178EB20A"),
                    Name = "FairWayBank",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
        }
    }
}
