using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingWebApp.Migrations
{
    public partial class defaultdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("7d0a0c94-ac38-44bf-84b2-bac47259863b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("c26669af-c2c0-47c8-9266-8b586b9b3fd8"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("6495bef3-04bf-4bc7-b407-958681347e6e"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6495bef3-04bf-4bc7-b407-958681347e6e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c26669af-c2c0-47c8-9266-8b586b9b3fd8"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("7d0a0c94-ac38-44bf-84b2-bac47259863b"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
