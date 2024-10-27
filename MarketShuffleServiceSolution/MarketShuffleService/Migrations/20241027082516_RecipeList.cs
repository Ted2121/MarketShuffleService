using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketShuffleService.Migrations
{
    public partial class RecipeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLists", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecipeListRows",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ResourceName = table.Column<string>(type: "longtext", nullable: false),
                    Area = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false),
                    RecipeListId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeListRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeListRows_RecipeLists_RecipeListId",
                        column: x => x.RecipeListId,
                        principalTable: "RecipeLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeListRows_RecipeListId",
                table: "RecipeListRows",
                column: "RecipeListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeListRows");

            migrationBuilder.DropTable(
                name: "RecipeLists");
        }
    }
}
