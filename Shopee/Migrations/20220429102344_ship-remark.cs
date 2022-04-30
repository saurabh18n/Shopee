using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class shipremark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_Orders_OrderId",
                table: "Remarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_Users_ByUserId",
                table: "Remarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings");

            migrationBuilder.DropIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Remarks",
                table: "Remarks");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dd5bea-9cbe-41d4-9618-0779365f3407"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8f762efe-cd48-4168-b1fd-74be1daf40a9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("910b81bd-57a4-400f-b2a9-b2cf24770f88"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91944e73-03c3-4f80-86a0-2d1437b31ad7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c30288b6-105e-4250-baf8-b63f3d25a050"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd3ea37a-0c6d-41c4-a0db-2cf89c9a8331"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53b05145-8975-48bb-b88e-a8d99cd33138"));

            migrationBuilder.RenameTable(
                name: "Remarks",
                newName: "order_remarks");

            migrationBuilder.RenameIndex(
                name: "IX_Remarks_OrderId",
                table: "order_remarks",
                newName: "IX_order_remarks_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Remarks_ByUserId",
                table: "order_remarks",
                newName: "IX_order_remarks_ByUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "order_remarks",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_remarks",
                table: "order_remarks",
                column: "Id");

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
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("aa24fb08-0236-4920-a65b-3257a47f90f9"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders",
                column: "ShippingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_order_remarks_Orders_OrderId",
                table: "order_remarks",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_remarks_Users_ByUserId",
                table: "order_remarks",
                column: "ByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippings_ShippingId",
                table: "Orders",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_remarks_Orders_OrderId",
                table: "order_remarks");

            migrationBuilder.DropForeignKey(
                name: "FK_order_remarks_Users_ByUserId",
                table: "order_remarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippings_ShippingId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_remarks",
                table: "order_remarks");

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

            migrationBuilder.RenameTable(
                name: "order_remarks",
                newName: "Remarks");

            migrationBuilder.RenameIndex(
                name: "IX_order_remarks_OrderId",
                table: "Remarks",
                newName: "IX_Remarks_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_order_remarks_ByUserId",
                table: "Remarks",
                newName: "IX_Remarks_ByUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Remarks",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Remarks",
                table: "Remarks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("63dd5bea-9cbe-41d4-9618-0779365f3407"), "Mobile", null },
                    { new Guid("8f762efe-cd48-4168-b1fd-74be1daf40a9"), "Household", null },
                    { new Guid("910b81bd-57a4-400f-b2a9-b2cf24770f88"), "Electronics", null },
                    { new Guid("91944e73-03c3-4f80-86a0-2d1437b31ad7"), "Fession", null },
                    { new Guid("c30288b6-105e-4250-baf8-b63f3d25a050"), "TV", null },
                    { new Guid("fd3ea37a-0c6d-41c4-a0db-2cf89c9a8331"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("53b05145-8975-48bb-b88e-a8d99cd33138"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_Orders_OrderId",
                table: "Remarks",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_Users_ByUserId",
                table: "Remarks",
                column: "ByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
