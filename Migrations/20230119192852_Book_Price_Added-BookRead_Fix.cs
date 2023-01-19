using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaulBejinariu_Project.Migrations
{
    public partial class Book_Price_AddedBookRead_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookRead_BookReadId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookReadId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookReadId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookRead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_BookRead_BookId",
                table: "BookRead",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRead_Book_BookId",
                table: "BookRead",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRead_Book_BookId",
                table: "BookRead");

            migrationBuilder.DropIndex(
                name: "IX_BookRead_BookId",
                table: "BookRead");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookRead");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookReadId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookReadId",
                table: "Book",
                column: "BookReadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookRead_BookReadId",
                table: "Book",
                column: "BookReadId",
                principalTable: "BookRead",
                principalColumn: "Id");
        }
    }
}
