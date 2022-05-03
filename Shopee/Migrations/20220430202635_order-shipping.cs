using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class ordershipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders");

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
                    { new Guid("28316826-6e00-4e93-8415-23e3ab871b4c"), "Electronics", null },
                    { new Guid("2f0bcd66-bce8-43ba-8db1-47f52aa5ef07"), "Mobile", null },
                    { new Guid("620cb80c-3c3c-4057-b063-e7bbceb652c3"), "Fession", null },
                    { new Guid("70dc31c8-b98e-4376-afb5-d260dc9c9b7d"), "Household", null },
                    { new Guid("8bf7be48-f554-49ba-bcbb-5ac2f6c828e5"), "TV", null },
                    { new Guid("91f667dd-8bd9-48d7-9ffa-69f3e189f182"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("f8bf3cd8-2d02-454a-b495-0341d8c6b57f"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings");

            migrationBuilder.DropIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("b5f916fc-473e-4de4-bcf1-5b0744b2b215"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders",
                column: "ShippingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingId",
                table: "Orders",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id");
        }
    }
}
