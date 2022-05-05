using Microsoft.EntityFrameworkCore.Migrations;

namespace Okul.DAL.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentDepartmen",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentDepartmen",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
