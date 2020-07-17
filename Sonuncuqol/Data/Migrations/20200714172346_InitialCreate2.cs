using Microsoft.EntityFrameworkCore.Migrations;

namespace Sonuncuqol.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabelId",
                table: "Posts",
                type: "int",
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
