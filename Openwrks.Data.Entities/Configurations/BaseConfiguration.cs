using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Openwrks.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Data.Entities.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T>
        where T : class, IEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.CreatedOn).ValueGeneratedOnAdd().IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifiedOn).ValueGeneratedOnAddOrUpdate().IsRequired()
                .HasDefaultValueSql("GETDATE()");
            
        }
    }
}