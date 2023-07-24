using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BooksId",
                table: "Authors",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BooksId",
                table: "Authors",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BooksId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BooksId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Authors");
        }
    }
}
