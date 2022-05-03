using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class productadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b44396a-485d-4766-871e-086b36c493bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21bbf184-af40-4e3a-ab40-2005a311c453"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2240d56e-176a-4ac8-9749-de8fa17e0169"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("85689d5e-322d-4641-919f-9b88cbd1a97f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9305941d-b34b-4a99-8bda-af2844b0be9b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f92936f2-c9b6-43ff-a351-4af997e3075a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22017f1f-f2cc-4f35-aef3-e17a9e6fd194"));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "Products",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0797ac53-ac60-4b41-b1aa-3f4348e28099"), "Fession", null },
                    { new Guid("2d16833a-f96d-4c19-b573-de903df42be2"), "All", null },
                    { new Guid("2e9f0114-83e7-4c82-8bb8-086f71f71b05"), "Electronics", null },
                    { new Guid("73d310a5-171f-4569-913b-f6e77ca1ce66"), "TV", null },
                    { new Guid("78d02d50-c27d-417b-b918-b682ecd1a7bc"), "Household", null },
                    { new Guid("9932c082-db21-45d9-89aa-1da136333924"), "Mobile", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("e0e96c90-01e1-47ec-b814-3ea1d80feb24"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0797ac53-ac60-4b41-b1aa-3f4348e28099"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2d16833a-f96d-4c19-b573-de903df42be2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2e9f0114-83e7-4c82-8bb8-086f71f71b05"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73d310a5-171f-4569-913b-f6e77ca1ce66"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("78d02d50-c27d-417b-b918-b682ecd1a7bc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9932c082-db21-45d9-89aa-1da136333924"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0e96c90-01e1-47ec-b814-3ea1d80feb24"));

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0b44396a-485d-4766-871e-086b36c493bb"), "Fession", null },
                    { new Guid("21bbf184-af40-4e3a-ab40-2005a311c453"), "Electronics", null },
                    { new Guid("2240d56e-176a-4ac8-9749-de8fa17e0169"), "Mobile", null },
                    { new Guid("85689d5e-322d-4641-919f-9b88cbd1a97f"), "TV", null },
                    { new Guid("9305941d-b34b-4a99-8bda-af2844b0be9b"), "Household", null },
                    { new Guid("f92936f2-c9b6-43ff-a351-4af997e3075a"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("22017f1f-f2cc-4f35-aef3-e17a9e6fd194"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
