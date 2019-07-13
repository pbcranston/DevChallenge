using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Data.Entities.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.AccountNumber).HasMaxLength(8).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();


            builder.HasOne(u => u.Bank)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.BankId)
                .OnDelete(DeleteBehavior.Restrict); // We should not be able to delete a bank that is linked to users

        }
    }
}
