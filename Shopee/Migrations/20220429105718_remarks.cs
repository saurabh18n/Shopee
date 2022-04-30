using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class remarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f81e396-0b9e-40d0-88b3-fb9ec64cd5ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("339626e7-af32-4d3e-94fe-a59ef6fc6017"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8151f7cf-c47f-437d-8d9a-07086fdb736a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("92c1dc23-b3ab-4d6f-9463-6a52c3bb62a5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec35292c-6621-4c4e-b48b-f1a5b13ee088"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6f16e3d-412a-4221-bdca-9ec9ff530552"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa24fb08-0236-4920-a65b-3257a47f90f9"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("09dd8870-1e89-4483-ac52-a7ab7462f54b"), "Fession", null },
                    { new Guid("5ef187df-d495-42c0-a2d8-2c08b357ca7a"), "Household", null },
                    { new Guid("7d3b5ad6-cb0f-46ef-b74d-2a58398375c2"), "Mobile", null },
                    { new Guid("9dbaee26-e86d-45e9-8f65-787bcd5eeea5"), "Electronics", null },
                    { new Guid("dec40b98-1061-4790-8e80-0357b7247f25"), "TV", null },
                    { new Guid("e06ecaa6-e081-4097-b9b1-9c2c7d8d1bbc"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("b5f916fc-473e-4de4-bcf1-5b0744b2b215"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("09dd8870-1e89-4483-ac52-a7ab7462f54b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ef187df-d495-42c0-a2d8-2c08b357ca7a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d3b5ad6-cb0f-46ef-b74d-2a58398375c2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9dbaee26-e86d-45e9-8f65-787bcd5eeea5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dec40b98-1061-4790-8e80-0357b7247f25"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e06ecaa6-e081-4097-b9b1-9c2c7d8d1bbc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5f916fc-473e-4de4-bcf1-5b0744b2b215"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("2f81e396-0b9e-40d0-88b3-fb9ec64cd5ba"), "Fession", null },
                    { new Guid("339626e7-af32-4d3e-94fe-a59ef6fc6017"), "All", null },
                    { new Guid("8151f7cf-c47f-437d-8d9a-07086fdb736a"), "Household", null },
                    { new Guid("92c1dc23-b3ab-4d6f-9463-6a52c3bb62a5"), "TV", null },
                    { new Guid("ec35292c-6621-4c4e-b48b-f1a5b13ee088"), "Electronics", null },
                    { new Guid("f6f16e3d-412a-4221-bdca-9ec9ff530552"), "Mobile", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("aa24fb08-0236-4920-a65b-3257a47f90f9"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
