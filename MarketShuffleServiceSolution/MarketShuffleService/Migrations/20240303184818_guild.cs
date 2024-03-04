using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketShuffleService.Migrations
{
    public partial class guild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Difficult = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Class = table.Column<string>(type: "longtext", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Exoed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    SeenOnline = table.Column<TimeOnly>(type: "time", nullable: false),
                    Ap = table.Column<int>(type: "int", nullable: false),
                    Mp = table.Column<int>(type: "int", nullable: false),
                    GuildId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Guilds_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GuildId",
                table: "Players",
                column: "GuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Guilds");
        }
    }
}
