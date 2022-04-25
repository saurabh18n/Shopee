using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class morecategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a0b487f0-73ec-404e-b222-cce4eef56aee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e06de33-2ffc-4603-8963-4bdcd95ecd53"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("e1855d37-96ff-44b7-92e3-aa856d3b7b9b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("800ee0db-d79c-48a7-bbb0-45ce2c9a3712"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("070b5130-166e-4ed2-9f13-4cf5050732a6"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("dbabe799-598e-40ba-b50a-9855b8c0ac3b"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CartItems",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f16a752f-e8cc-41ec-9f7c-ae5394bc3e99"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("c93fd5f9-550b-4056-81db-fc3ad783597e"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("4e10fea4-43d7-4599-906d-cf9496fdfc53"), "All", null },
                    { new Guid("542f79a9-ed5c-4ab5-ad94-cf63f96d5186"), "Electronics", null },
                    { new Guid("b4df9822-d658-464e-b921-6b38044b5d9c"), "Fession", null },
                    { new Guid("e318d594-29fd-4b1d-b9dd-e6345e6b9b64"), "Household", null },
                    { new Guid("eb5a2364-68bf-431f-ad8f-ccb665cf1884"), "Mobile", null },
                    { new Guid("f118b51c-2ec1-4419-9a98-a27d1b373e6c"), "TV", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("17788096-d484-40c4-9fc9-ee062b4c2ac7"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4e10fea4-43d7-4599-906d-cf9496fdfc53"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("542f79a9-ed5c-4ab5-ad94-cf63f96d5186"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b4df9822-d658-464e-b921-6b38044b5d9c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e318d594-29fd-4b1d-b9dd-e6345e6b9b64"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb5a2364-68bf-431f-ad8f-ccb665cf1884"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f118b51c-2ec1-4419-9a98-a27d1b373e6c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("17788096-d484-40c4-9fc9-ee062b4c2ac7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("800ee0db-d79c-48a7-bbb0-45ce2c9a3712"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("e1855d37-96ff-44b7-92e3-aa856d3b7b9b"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("dbabe799-598e-40ba-b50a-9855b8c0ac3b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("070b5130-166e-4ed2-9f13-4cf5050732a6"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CartItems",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c93fd5f9-550b-4056-81db-fc3ad783597e"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("f16a752f-e8cc-41ec-9f7c-ae5394bc3e99"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[] { new Guid("a0b487f0-73ec-404e-b222-cce4eef56aee"), "All", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("2e06de33-2ffc-4603-8963-4bdcd95ecd53"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
