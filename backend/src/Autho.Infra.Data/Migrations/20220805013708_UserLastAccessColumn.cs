using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autho.Principal.Migrations
{
    public partial class UserLastAccessColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccess",
                table: "User",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastAccess",
                table: "User");
        }
    }
}
