using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class shippings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ProcessByUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_Orders_OrderId",
                table: "Shipping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipping",
                table: "Shipping");

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

            migrationBuilder.RenameTable(
                name: "Shipping",
                newName: "Shippings");

            migrationBuilder.RenameIndex(
                name: "IX_Shipping_OrderId",
                table: "Shippings",
                newName: "IX_Shippings_OrderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessByUserId",
                table: "Orders",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<int>(
                name: "ShippingType",
                table: "Shippings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("016c0f7c-b210-4022-944d-0a3822c344f0"), "Mobile", null },
                    { new Guid("17ece5d4-1a21-4d0a-bbc2-55dbb4c1a328"), "Household", null },
                    { new Guid("242caee3-3892-4b7c-8489-e30df33224eb"), "Electronics", null },
                    { new Guid("57193e6b-6360-4034-b0bf-259fd10c3456"), "All", null },
                    { new Guid("68d1739e-a840-433a-bd2f-c0dc6a45479e"), "Fession", null },
                    { new Guid("b9eeaba8-42a1-42b7-85d3-df8040b0f0f3"), "TV", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("b870f153-7518-4bbd-af40-7ad6d5f25f23"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ProcessByUserId",
                table: "Orders",
                column: "ProcessByUserId",
                principalTable: "Users",
                principalColumn: "Id");

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
                name: "FK_Orders_Users_ProcessByUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("016c0f7c-b210-4022-944d-0a3822c344f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17ece5d4-1a21-4d0a-bbc2-55dbb4c1a328"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("242caee3-3892-4b7c-8489-e30df33224eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("57193e6b-6360-4034-b0bf-259fd10c3456"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("68d1739e-a840-433a-bd2f-c0dc6a45479e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9eeaba8-42a1-42b7-85d3-df8040b0f0f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b870f153-7518-4bbd-af40-7ad6d5f25f23"));

            migrationBuilder.DropColumn(
                name: "ShippingType",
                table: "Shippings");

            migrationBuilder.RenameTable(
                name: "Shippings",
                newName: "Shipping");

            migrationBuilder.RenameIndex(
                name: "IX_Shippings_OrderId",
                table: "Shipping",
                newName: "IX_Shipping_OrderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProcessByUserId",
                table: "Orders",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipping",
                table: "Shipping",
                column: "Id");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("b48f370e-e673-43c8-99a7-f97d3ee52fb5"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ProcessByUserId",
                table: "Orders",
                column: "ProcessByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_Orders_OrderId",
                table: "Shipping",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
