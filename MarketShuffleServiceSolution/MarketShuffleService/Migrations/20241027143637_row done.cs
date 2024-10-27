using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketShuffleService.Migrations
{
    public partial class rowdone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "RecipeListRows",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "RecipeListRows");
        }
    }
}
