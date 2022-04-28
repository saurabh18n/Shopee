using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class orderaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60a1b5e9-5062-4ab7-bbcc-58a2fa036c33"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("897ab916-f6c2-4909-9f6d-1cdb134c3f67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91c29fda-1d51-4b1c-9381-57775fcf74a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("acb920b8-b999-441e-8f5a-8b7c8609c733"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c97c7d4b-5992-4562-8a5f-5b950f5b2ff1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2e077a6-ad1a-4e27-b370-73c0962984ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("272584f0-e863-49bb-99b8-4095ed9376ec"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("903e4dcd-37a3-4bbf-a0bc-b68b2eb11544"), "Electronics", null },
                    { new Guid("a35d2589-23d5-41d8-9b2c-78fbdebeab0a"), "All", null },
                    { new Guid("b30b6b16-8da9-4fe9-9028-57016069d254"), "TV", null },
                    { new Guid("dae3526a-e57a-4c68-a78a-80844a8777f7"), "Mobile", null },
                    { new Guid("e1775b64-bfb6-4569-acb2-84b40ada182e"), "Fession", null },
                    { new Guid("f4e39b85-43c9-4e15-adc8-1397ddd4f88e"), "Household", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("ed2a0350-94f8-4a40-ad7f-e47110a5ad52"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("903e4dcd-37a3-4bbf-a0bc-b68b2eb11544"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a35d2589-23d5-41d8-9b2c-78fbdebeab0a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b30b6b16-8da9-4fe9-9028-57016069d254"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dae3526a-e57a-4c68-a78a-80844a8777f7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e1775b64-bfb6-4569-acb2-84b40ada182e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4e39b85-43c9-4e15-adc8-1397ddd4f88e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed2a0350-94f8-4a40-ad7f-e47110a5ad52"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("60a1b5e9-5062-4ab7-bbcc-58a2fa036c33"), "Household", null },
                    { new Guid("897ab916-f6c2-4909-9f6d-1cdb134c3f67"), "Mobile", null },
                    { new Guid("91c29fda-1d51-4b1c-9381-57775fcf74a2"), "All", null },
                    { new Guid("acb920b8-b999-441e-8f5a-8b7c8609c733"), "Electronics", null },
                    { new Guid("c97c7d4b-5992-4562-8a5f-5b950f5b2ff1"), "TV", null },
                    { new Guid("e2e077a6-ad1a-4e27-b370-73c0962984ac"), "Fession", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("272584f0-e863-49bb-99b8-4095ed9376ec"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
