using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaulBejinariu_Project.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookWishlist_BookWishlistId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookWishlistId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookWishlistId",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_BookWishlist_BookId",
                table: "BookWishlist",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookWishlist_Book_BookId",
                table: "BookWishlist",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookWishlist_Book_BookId",
                table: "BookWishlist");

            migrationBuilder.DropIndex(
                name: "IX_BookWishlist_BookId",
                table: "BookWishlist");

            migrationBuilder.AddColumn<int>(
                name: "BookWishlistId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookWishlistId",
                table: "Book",
                column: "BookWishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookWishlist_BookWishlistId",
                table: "Book",
                column: "BookWishlistId",
                principalTable: "BookWishlist",
                principalColumn: "Id");
        }
    }
}
