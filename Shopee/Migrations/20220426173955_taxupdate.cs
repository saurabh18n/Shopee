using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class taxupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new Guid("bcfc7f84-a29c-41d1-8fd0-47a61f6f9500"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("e1855d37-96ff-44b7-92e3-aa856d3b7b9b"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<float>(
                name: "tax",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c1f02b0a-7649-49ca-a91d-73ff1e9177fa"),
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
                defaultValue: new Guid("e60660a6-b2b2-41d8-bb0b-de656030cf9d"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("f16a752f-e8cc-41ec-9f7c-ae5394bc3e99"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0e0a29de-2726-4a84-8d4e-1b82ac509a80"), "Household", null },
                    { new Guid("5935173e-43da-4c55-bc58-1ef5e053e0da"), "Mobile", null },
                    { new Guid("a5f6237f-adc0-497f-ad84-3fbd01da81f0"), "Electronics", null },
                    { new Guid("ccf467bb-6696-45d4-875b-ce6659113897"), "Fession", null },
                    { new Guid("cf0acdb8-10cf-4680-a7ec-3b021a41f38d"), "All", null },
                    { new Guid("f6a91c55-25d7-409d-988d-55d21f393985"), "TV", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("4bdd3b61-70e6-4018-b217-3e0e9dc39fd8"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0e0a29de-2726-4a84-8d4e-1b82ac509a80"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5935173e-43da-4c55-bc58-1ef5e053e0da"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a5f6237f-adc0-497f-ad84-3fbd01da81f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ccf467bb-6696-45d4-875b-ce6659113897"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cf0acdb8-10cf-4680-a7ec-3b021a41f38d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6a91c55-25d7-409d-988d-55d21f393985"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4bdd3b61-70e6-4018-b217-3e0e9dc39fd8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("e1855d37-96ff-44b7-92e3-aa856d3b7b9b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("bcfc7f84-a29c-41d1-8fd0-47a61f6f9500"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<decimal>(
                name: "tax",
                table: "Products",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("070b5130-166e-4ed2-9f13-4cf5050732a6"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("c1f02b0a-7649-49ca-a91d-73ff1e9177fa"))
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
                oldDefaultValue: new Guid("e60660a6-b2b2-41d8-bb0b-de656030cf9d"))
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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("17788096-d484-40c4-9fc9-ee062b4c2ac7"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
