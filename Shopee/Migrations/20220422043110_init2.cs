using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02e6af33-4da7-4a0d-96a7-a380b116a28f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("513adede-7114-48cd-a66e-14f61dbd4187"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("bdd20660-0703-42b2-9c59-e6d644bff517"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("41bbecdd-5925-4249-a465-426e2bd1fcb4"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41bbecdd-5925-4249-a465-426e2bd1fcb4"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bdd20660-0703-42b2-9c59-e6d644bff517"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("513adede-7114-48cd-a66e-14f61dbd4187"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("02e6af33-4da7-4a0d-96a7-a380b116a28f"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }
    }
}
