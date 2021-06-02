using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentProject.Migrations
{
    public partial class addednewcoltospellerstab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "SpellersTabs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FavouriteFood",
                table: "SpellersTabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavouriteSport",
                table: "SpellersTabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavouriteTvShow",
                table: "SpellersTabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavouritesAuthor",
                table: "SpellersTabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Musician",
                table: "SpellersTabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviusExperience",
                table: "SpellersTabs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortBio",
                table: "SpellersTabs",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SpellersImgs",
                columns: table => new
                {
                    SpellersId = table.Column<int>(nullable: false),
                    SpellersName = table.Column<string>(nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    DateCreated = table.Column<string>(nullable: false),
                    DateUpdated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellersImgs", x => x.SpellersId);
                    table.ForeignKey(
                        name: "FK_SpellersImgs_SpellersTabs_SpellersId",
                        column: x => x.SpellersId,
                        principalTable: "SpellersTabs",
                        principalColumn: "SpellersId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellersImgs");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "FavouriteFood",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "FavouriteSport",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "FavouriteTvShow",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "FavouritesAuthor",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "Musician",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "PreviusExperience",
                table: "SpellersTabs");

            migrationBuilder.DropColumn(
                name: "ShortBio",
                table: "SpellersTabs");
        }
    }
}
