using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceLists.Migrations
{
    public partial class AddedOtherdbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColumnValues_ColumnId",
                table: "ProductColumnValues",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColumnValues_ProductId",
                table: "ProductColumnValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_PriceListId",
                table: "Columns",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceListId",
                table: "Products",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColumnValues_Columns_ColumnId",
                table: "ProductColumnValues",
                column: "ColumnId",
                principalTable: "Columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColumnValues_Products_ProductId",
                table: "ProductColumnValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColumnValues_Columns_ColumnId",
                table: "ProductColumnValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColumnValues_Products_ProductId",
                table: "ProductColumnValues");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_ProductColumnValues_ColumnId",
                table: "ProductColumnValues");

            migrationBuilder.DropIndex(
                name: "IX_ProductColumnValues_ProductId",
                table: "ProductColumnValues");
        }
    }
}
