using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreShoppingCart.Migrations
{
    public partial class addProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PPrice = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Pid);
                    table.ForeignKey(
                        name: "FK_Products_TblCat_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TblCat",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
