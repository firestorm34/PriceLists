using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PriceLists.Migrations
{
    public partial class Changeddiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ProductColumnValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ProductColumnValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
