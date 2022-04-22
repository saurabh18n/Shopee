using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class product_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_AddedById",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_images_Product_ProductId",
                table: "product_images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e885486d-4295-4500-a427-ee402772629b"));

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AddedById",
                table: "Products",
                newName: "IX_Products_AddedById");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("2b146721-aac6-4942-81c2-1610f75277e6"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("bf394a3d-7a60-42e0-90a5-ec487ce72fae"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("f29d4c92-48e4-4001-8e4f-43f53e70644f"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_product_images_Products_ProductId",
                table: "product_images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AddedById",
                table: "Products",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_images_Products_ProductId",
                table: "product_images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AddedById",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f29d4c92-48e4-4001-8e4f-43f53e70644f"));

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AddedById",
                table: "Product",
                newName: "IX_Product_AddedById");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bf394a3d-7a60-42e0-90a5-ec487ce72fae"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("2b146721-aac6-4942-81c2-1610f75277e6"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("e885486d-4295-4500-a427-ee402772629b"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_AddedById",
                table: "Product",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_images_Product_ProductId",
                table: "product_images",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
