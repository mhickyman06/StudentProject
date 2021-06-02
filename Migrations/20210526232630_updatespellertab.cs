using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentProject.Migrations
{
    public partial class updatespellertab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviusExperience",
                table: "SpellersTabs");

            migrationBuilder.AlterColumn<string>(
                name: "ShortBio",
                table: "SpellersTabs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortBio",
                table: "SpellersTabs",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PreviusExperience",
                table: "SpellersTabs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
