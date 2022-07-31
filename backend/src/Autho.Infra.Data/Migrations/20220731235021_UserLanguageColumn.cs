using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autho.Principal.Migrations
{
    public partial class UserLanguageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "User");
        }
    }
}
