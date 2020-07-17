using Microsoft.EntityFrameworkCore.Migrations;

namespace Sonuncuqol.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabelId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LabelId",
                table: "Posts",
                column: "LabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Labels_LabelId",
                table: "Posts",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Labels_LabelId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_LabelId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LabelId",
                table: "Posts");
        }
    }
}
