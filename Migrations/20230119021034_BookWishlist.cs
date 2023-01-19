using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaulBejinariu_Project.Migrations
{
    public partial class BookWishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookWishlistId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookWishlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookGenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookWishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookWishlist_BookGenre_BookGenreId",
                        column: x => x.BookGenreId,
                        principalTable: "BookGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookWishlistId",
                table: "Book",
                column: "BookWishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_BookWishlist_BookGenreId",
                table: "BookWishlist",
                column: "BookGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookWishlist_BookWishlistId",
                table: "Book",
                column: "BookWishlistId",
                principalTable: "BookWishlist",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookWishlist_BookWishlistId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookWishlist");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookWishlistId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookWishlistId",
                table: "Book");
        }
    }
}
