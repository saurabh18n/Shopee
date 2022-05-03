using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class remark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b7b6266-f645-4f56-837b-8aa936644ada"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f085bab-3516-4456-9fe5-b17058f62158"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8fa7261d-5d32-4d02-bef2-ee11525941fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f0f0657-c065-4989-a43f-f0c2c14c8be9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bf2af7c3-1f91-491e-8864-f31d7258acda"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ed34ee34-6aee-418c-b169-27715610ef7f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eaf06465-eec3-491f-bdbf-4de3c831bff2"));

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("22017f1f-f2cc-4f35-aef3-e17a9e6fd194"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0b7b6266-f645-4f56-837b-8aa936644ada"), "Mobile", null },
                    { new Guid("6f085bab-3516-4456-9fe5-b17058f62158"), "TV", null },
                    { new Guid("8fa7261d-5d32-4d02-bef2-ee11525941fe"), "Electronics", null },
                    { new Guid("9f0f0657-c065-4989-a43f-f0c2c14c8be9"), "All", null },
                    { new Guid("bf2af7c3-1f91-491e-8864-f31d7258acda"), "Fession", null },
                    { new Guid("ed34ee34-6aee-418c-b169-27715610ef7f"), "Household", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("eaf06465-eec3-491f-bdbf-4de3c831bff2"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
