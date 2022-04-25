using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductScore",
                table: "Products",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "ProductCost");

            migrationBuilder.CreateTable(
                name: "Metric",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSales = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    GrossValue = table.Column<double>(type: "float", nullable: false),
                    NetValue = table.Column<double>(type: "float", nullable: false),
                    ProductForeignId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metric_Products_ProductForeignId",
                        column: x => x.ProductForeignId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metric_ProductForeignId",
                table: "Metric",
                column: "ProductForeignId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metric");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                table: "Products",
                newName: "ProductScore");

            migrationBuilder.RenameColumn(
                name: "ProductCost",
                table: "Products",
                newName: "Price");
        }
    }
}
