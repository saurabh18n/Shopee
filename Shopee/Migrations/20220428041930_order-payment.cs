using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class orderpayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0e797c91-b9e0-48fa-9a4b-20e07b5b053a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("daf2a5c6-ae80-4b8a-993e-b940c6cbea18"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e50fea4b-d87b-4038-8294-e957931d2e7f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e86c65c1-d47f-410d-941a-76eb668ffa67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f855ddea-df69-458b-9935-0a0e7b7ccd55"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8cd83a1-983d-40bc-a710-0b23d93d716e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2b4c8d5-11e7-4e98-a787-5528d43a64ca"));

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pda",
                table: "Orders",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "pdb",
                table: "Orders",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("60a1b5e9-5062-4ab7-bbcc-58a2fa036c33"), "Household", null },
                    { new Guid("897ab916-f6c2-4909-9f6d-1cdb134c3f67"), "Mobile", null },
                    { new Guid("91c29fda-1d51-4b1c-9381-57775fcf74a2"), "All", null },
                    { new Guid("acb920b8-b999-441e-8f5a-8b7c8609c733"), "Electronics", null },
                    { new Guid("c97c7d4b-5992-4562-8a5f-5b950f5b2ff1"), "TV", null },
                    { new Guid("e2e077a6-ad1a-4e27-b370-73c0962984ac"), "Fession", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("272584f0-e863-49bb-99b8-4095ed9376ec"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60a1b5e9-5062-4ab7-bbcc-58a2fa036c33"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("897ab916-f6c2-4909-9f6d-1cdb134c3f67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91c29fda-1d51-4b1c-9381-57775fcf74a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("acb920b8-b999-441e-8f5a-8b7c8609c733"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c97c7d4b-5992-4562-8a5f-5b950f5b2ff1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2e077a6-ad1a-4e27-b370-73c0962984ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("272584f0-e863-49bb-99b8-4095ed9376ec"));

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "pda",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "pdb",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0e797c91-b9e0-48fa-9a4b-20e07b5b053a"), "Fession", null },
                    { new Guid("daf2a5c6-ae80-4b8a-993e-b940c6cbea18"), "Household", null },
                    { new Guid("e50fea4b-d87b-4038-8294-e957931d2e7f"), "Mobile", null },
                    { new Guid("e86c65c1-d47f-410d-941a-76eb668ffa67"), "Electronics", null },
                    { new Guid("f855ddea-df69-458b-9935-0a0e7b7ccd55"), "TV", null },
                    { new Guid("f8cd83a1-983d-40bc-a710-0b23d93d716e"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("f2b4c8d5-11e7-4e98-a787-5528d43a64ca"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
