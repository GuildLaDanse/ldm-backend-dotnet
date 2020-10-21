using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaDanse.Persistence.Migrations
{
    public partial class GameSlugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "gameSlug",
                table: "GameRealm",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_unicode_ci");
            
            migrationBuilder.Sql(@"
                UPDATE GameRealm SET gameSlug = REPLACE(LOWER(name), ' ', '-')
                ");

            migrationBuilder.AddColumn<string>(
                name: "gameSlug",
                table: "GameGuild",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_unicode_ci");
            
            migrationBuilder.Sql(@"
                UPDATE GameGuild SET gameSlug = REPLACE(LOWER(name), ' ', '-')
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gameSlug",
                table: "GameRealm");

            migrationBuilder.DropColumn(
                name: "gameSlug",
                table: "GameGuild");
        }
    }
}
