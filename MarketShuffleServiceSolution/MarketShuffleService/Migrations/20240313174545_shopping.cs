using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketShuffleService.Migrations
{
    public partial class shopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CraftUntil",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderInCategory",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Items",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "RelistCount",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldCount",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UseFor",
                table: "Items",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CraftUntil",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderInCategory",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RelistCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SoldCount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UseFor",
                table: "Items");
        }
    }
}
