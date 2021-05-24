using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentProject.Migrations
{
    public partial class updss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpellersName",
                table: "SpellersVideos",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpellersName",
                table: "SpellersVideos");
        }
    }
}
