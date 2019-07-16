﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Openwrks.Data.Db;

namespace Openwrks.Data.Db.Migrations
{
    [DbContext(typeof(OpenwrksContext))]
    partial class OpenwrksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Openwrks.Data.Entities.Entities.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Bank");

                    b.HasData(
                        new
                        {
                            Id = new Guid("222ea055-afaf-47d2-8cfe-260a0be88658"),
                            CreatedOn = new DateTime(2019, 7, 16, 21, 34, 18, 254, DateTimeKind.Local).AddTicks(2048),
                            ModifiedOn = new DateTime(2019, 7, 16, 21, 34, 18, 256, DateTimeKind.Local).AddTicks(995),
                            Name = "BizfiBank"
                        },
                        new
                        {
                            Id = new Guid("8d4b7236-94c4-4949-a924-9b4e178eb20a"),
                            CreatedOn = new DateTime(2019, 7, 16, 21, 34, 18, 256, DateTimeKind.Local).AddTicks(1424),
                            ModifiedOn = new DateTime(2019, 7, 16, 21, 34, 18, 256, DateTimeKind.Local).AddTicks(1438),
                            Name = "FairWayBank"
                        });
                });

            modelBuilder.Entity("Openwrks.Data.Entities.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<Guid>("BankId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Openwrks.Data.Entities.Entities.User", b =>
                {
                    b.HasOne("Openwrks.Data.Entities.Entities.Bank", "Bank")
                        .WithMany("Users")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
