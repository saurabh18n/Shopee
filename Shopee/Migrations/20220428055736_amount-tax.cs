using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class amounttax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("1a7f3805-de49-4789-85ba-dee8e3260055"), "All", null },
                    { new Guid("44704e8d-9e7e-4c14-a186-c6fcea6dd846"), "Electronics", null },
                    { new Guid("725f0627-4acb-4efb-9f8e-977d4ba9f0c1"), "Mobile", null },
                    { new Guid("8a9c9458-7ff8-4362-a46d-982e0355bbcf"), "TV", null },
                    { new Guid("dfcd9725-e5fb-4bca-9c3f-34ef110f5e44"), "Household", null },
                    { new Guid("f55392db-c0a7-4968-963e-275737be77b9"), "Fession", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("b48f370e-e673-43c8-99a7-f97d3ee52fb5"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1a7f3805-de49-4789-85ba-dee8e3260055"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44704e8d-9e7e-4c14-a186-c6fcea6dd846"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("725f0627-4acb-4efb-9f8e-977d4ba9f0c1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a9c9458-7ff8-4362-a46d-982e0355bbcf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dfcd9725-e5fb-4bca-9c3f-34ef110f5e44"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f55392db-c0a7-4968-963e-275737be77b9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b48f370e-e673-43c8-99a7-f97d3ee52fb5"));

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Orders");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("6de9a8ff-9583-4e41-a1f6-df8f57247559"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
