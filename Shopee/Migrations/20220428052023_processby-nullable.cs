using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class processbynullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("3639a878-2944-4840-938a-162bb39c7ca4"), "Electronics", null },
                    { new Guid("432dbcd0-0efb-4c99-b527-d8cde50d312c"), "All", null },
                    { new Guid("6d11cab4-521a-4bc6-9da6-d5d8d06d38bb"), "Household", null },
                    { new Guid("72fd8c7c-659a-4506-90e2-7f6a39d18e4b"), "Fession", null },
                    { new Guid("9f867ee0-5e43-4d97-9ae9-0e93b619ea30"), "TV", null },
                    { new Guid("c5909055-b579-4291-b5ae-0456f816f560"), "Mobile", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("6de9a8ff-9583-4e41-a1f6-df8f57247559"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3639a878-2944-4840-938a-162bb39c7ca4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("432dbcd0-0efb-4c99-b527-d8cde50d312c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d11cab4-521a-4bc6-9da6-d5d8d06d38bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("72fd8c7c-659a-4506-90e2-7f6a39d18e4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f867ee0-5e43-4d97-9ae9-0e93b619ea30"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c5909055-b579-4291-b5ae-0456f816f560"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6de9a8ff-9583-4e41-a1f6-df8f57247559"));

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("33eca36d-f8a9-44fb-87fe-d466fcb7e073"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
