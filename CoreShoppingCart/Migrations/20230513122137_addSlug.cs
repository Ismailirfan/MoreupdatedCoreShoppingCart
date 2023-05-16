using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreShoppingCart.Migrations
{
    public partial class addSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "TblCat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "TblCat");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");
        }
    }
}
