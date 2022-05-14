using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class addresstouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("1cda08c1-cb82-443d-915b-ffc695b2d3c6"), "Electronics", null },
                    { new Guid("3cadb6c9-adbe-4173-894d-cddc4009b260"), "Household", null },
                    { new Guid("66771807-65c3-40d1-84d4-46f423e7a291"), "All", null },
                    { new Guid("99d87c1e-d73b-40e1-bba3-87cfcc8d2faa"), "Mobile", null },
                    { new Guid("d3a33767-99d6-4e37-8853-62e9143ec27e"), "Fession", null },
                    { new Guid("e8830db3-c520-4e0d-a062-08bfa3e7b4a7"), "TV", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("d9d16701-1fc1-4ce2-8c2a-82234ed2d407"), null, "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1cda08c1-cb82-443d-915b-ffc695b2d3c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3cadb6c9-adbe-4173-894d-cddc4009b260"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66771807-65c3-40d1-84d4-46f423e7a291"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("99d87c1e-d73b-40e1-bba3-87cfcc8d2faa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3a33767-99d6-4e37-8853-62e9143ec27e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8830db3-c520-4e0d-a062-08bfa3e7b4a7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9d16701-1fc1-4ce2-8c2a-82234ed2d407"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("e0e96c90-01e1-47ec-b814-3ea1d80feb24"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
