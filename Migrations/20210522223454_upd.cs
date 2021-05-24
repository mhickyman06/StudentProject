using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentProject.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpellersTabSpellersId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpellersTabSpellersId",
                table: "AspNetUsers",
                column: "SpellersTabSpellersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SpellersTabs_SpellersTabSpellersId",
                table: "AspNetUsers",
                column: "SpellersTabSpellersId",
                principalTable: "SpellersTabs",
                principalColumn: "SpellersId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SpellersTabs_SpellersTabSpellersId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpellersTabSpellersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpellersTabSpellersId",
                table: "AspNetUsers");
        }
    }
}
