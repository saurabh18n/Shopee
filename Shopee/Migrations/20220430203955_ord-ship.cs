using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class ordship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28316826-6e00-4e93-8415-23e3ab871b4c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f0bcd66-bce8-43ba-8db1-47f52aa5ef07"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("620cb80c-3c3c-4057-b063-e7bbceb652c3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70dc31c8-b98e-4376-afb5-d260dc9c9b7d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bf7be48-f554-49ba-bcbb-5ac2f6c828e5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91f667dd-8bd9-48d7-9ffa-69f3e189f182"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8bf3cd8-2d02-454a-b495-0341d8c6b57f"));

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "Orders");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("eaf06465-eec3-491f-bdbf-4de3c831bff2"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingId",
                table: "Orders",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("28316826-6e00-4e93-8415-23e3ab871b4c"), "Electronics", null },
                    { new Guid("2f0bcd66-bce8-43ba-8db1-47f52aa5ef07"), "Mobile", null },
                    { new Guid("620cb80c-3c3c-4057-b063-e7bbceb652c3"), "Fession", null },
                    { new Guid("70dc31c8-b98e-4376-afb5-d260dc9c9b7d"), "Household", null },
                    { new Guid("8bf7be48-f554-49ba-bcbb-5ac2f6c828e5"), "TV", null },
                    { new Guid("91f667dd-8bd9-48d7-9ffa-69f3e189f182"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("f8bf3cd8-2d02-454a-b495-0341d8c6b57f"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
