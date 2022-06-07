using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniShopApp.Data.Migrations
{
    public partial class addmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Qantity",
                table: "CardItems",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CardItems",
                newName: "Qantity");
        }
    }
}
