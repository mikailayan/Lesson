using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_2504.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BookPrice",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookCreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 26, 12, 24, 27, 660, DateTimeKind.Local).AddTicks(2),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookDetailYear",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 2022,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BookDetailISBN",
                table: "BookDetails",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "0000-0000-0000",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorCreatedDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 26, 12, 24, 27, 640, DateTimeKind.Local).AddTicks(2676),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 25, 14, 6, 29, 953, DateTimeKind.Local).AddTicks(5698));

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.BookAuthorId);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImageUrl", "BookName", "CategoryId" },
                values: new object[] { 1, "https://www.kelepirkitap.com/Uploads/UrunResimleri/nobel-yayinlari-yonetim-bilisim-sistemle-7411.jpg", "Yönetim Bilişim Sistemleri", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImageUrl", "BookName", "CategoryId" },
                values: new object[] { 2, "https://wmscripti.com/wp-content/uploads/2014/12/seckin-azphp.png", "A dan Z ye php", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookImageUrl", "BookName", "CategoryId" },
                values: new object[] { 3, "https://kitapdostum.com/Content/Images/Kitap/302276.jpg", "Sefiller", 3 });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "BookAuthorId", "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "BookDetailId", "BookDetailCity", "BookDetailCountry", "BookDetailYear", "BookId" },
                values: new object[,]
                {
                    { 1, null, null, 2021, 1 },
                    { 2, null, null, 2020, 2 },
                    { 3, null, null, 2022, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_BookId",
                table: "BookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Books_BookId",
                table: "BookDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Books_BookId",
                table: "BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_BookId",
                table: "BookDetails");

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "BookDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "BookDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "BookDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "BookPrice",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "BookName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookCreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 26, 12, 24, 27, 660, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.AlterColumn<int>(
                name: "BookDetailYear",
                table: "BookDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2022);

            migrationBuilder.AlterColumn<string>(
                name: "BookDetailISBN",
                table: "BookDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "0000-0000-0000");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorCreatedDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 25, 14, 6, 29, 953, DateTimeKind.Local).AddTicks(5698),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 26, 12, 24, 27, 640, DateTimeKind.Local).AddTicks(2676));
        }
    }
}
