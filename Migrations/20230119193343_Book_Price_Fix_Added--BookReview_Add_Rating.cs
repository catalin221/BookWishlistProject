using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaulBejinariu_Project.Migrations
{
    public partial class Book_Price_Fix_AddedBookReview_Add_Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "BookReview",
                type: "decimal(2,1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Book",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "BookReview",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)");
        }
    }
}
