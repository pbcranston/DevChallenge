using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Openwrks.Data.Db.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { new Guid("222ea055-afaf-47d2-8cfe-260a0be88658"), new DateTime(2019, 7, 16, 21, 34, 18, 254, DateTimeKind.Local).AddTicks(2048), "BizfiBank" });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[] { new Guid("8d4b7236-94c4-4949-a924-9b4e178eb20a"), new DateTime(2019, 7, 16, 21, 34, 18, 256, DateTimeKind.Local).AddTicks(1424), "FairWayBank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: new Guid("222ea055-afaf-47d2-8cfe-260a0be88658"));

            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: new Guid("8d4b7236-94c4-4949-a924-9b4e178eb20a"));
        }
    }
}
