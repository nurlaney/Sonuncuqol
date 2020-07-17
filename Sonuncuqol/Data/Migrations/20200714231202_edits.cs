using Microsoft.EntityFrameworkCore.Migrations;

namespace Sonuncuqol.Data.Migrations
{
    public partial class edits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgetToken",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Writers",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Writers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForgetToken",
                table: "Admins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
