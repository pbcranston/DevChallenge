using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openwrks.Data.Entities.Configurations;

namespace Openwrks.Data.Db
{
    public class OpenwrksContext : DbContext
    {
        public OpenwrksContext(DbContextOptions<OpenwrksContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BankConfiguration());

            // Ensure we use DateTime2 fields in SQL
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime)))
            {
                property.Relational().ColumnType = "datetime2";
            }

            base.OnModelCreating(builder);
        }

    }
}
