using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketShuffleService.Migrations
{
    public partial class RecipeListRowLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "RecipeListRows",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "RecipeListRows");
        }
    }
}
