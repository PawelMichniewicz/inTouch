using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunicationWebApi.Migrations
{
    public partial class UserLoginRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "Nickname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Users",
                newName: "Login");
        }
    }
}
