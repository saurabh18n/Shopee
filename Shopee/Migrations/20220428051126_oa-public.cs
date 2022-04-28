using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class oapublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("1c2e40b0-7200-4548-b7eb-9d7813150942"), "Household", null },
                    { new Guid("280459f3-fd08-4927-9f90-4ea7ef057340"), "All", null },
                    { new Guid("61ece1b7-d5bf-4d4e-acc8-a7402d6cb6dd"), "Fession", null },
                    { new Guid("925ff2ac-83d9-403e-899e-3837f8582823"), "Electronics", null },
                    { new Guid("da0a4ed7-307d-4fea-97e0-faea2ebf0807"), "Mobile", null },
                    { new Guid("e44e97b6-8244-4279-b792-f71eed4c2b4d"), "TV", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("33eca36d-f8a9-44fb-87fe-d466fcb7e073"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c2e40b0-7200-4548-b7eb-9d7813150942"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("280459f3-fd08-4927-9f90-4ea7ef057340"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61ece1b7-d5bf-4d4e-acc8-a7402d6cb6dd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("925ff2ac-83d9-403e-899e-3837f8582823"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("da0a4ed7-307d-4fea-97e0-faea2ebf0807"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e44e97b6-8244-4279-b792-f71eed4c2b4d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33eca36d-f8a9-44fb-87fe-d466fcb7e073"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("ed2a0350-94f8-4a40-ad7f-e47110a5ad52"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
