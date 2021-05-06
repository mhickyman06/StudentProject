using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentProject.Migrations
{
    public partial class addinglocalgovtschoolstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalGovtSchoolsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocalGovtSchool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalGovtSchool", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocalGovtSchoolsId",
                table: "AspNetUsers",
                column: "LocalGovtSchoolsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LocalGovtSchool_LocalGovtSchoolsId",
                table: "AspNetUsers",
                column: "LocalGovtSchoolsId",
                principalTable: "LocalGovtSchool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LocalGovtSchool_LocalGovtSchoolsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LocalGovtSchool");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocalGovtSchoolsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocalGovtSchoolsId",
                table: "AspNetUsers");
        }
    }
}
