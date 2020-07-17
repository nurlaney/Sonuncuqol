using Microsoft.EntityFrameworkCore.Migrations;

namespace Sonuncuqol.Data.Migrations
{
    public partial class edits1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForgetToken",
                table: "Admins",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgetToken",
                table: "Admins");
        }
    }
}
