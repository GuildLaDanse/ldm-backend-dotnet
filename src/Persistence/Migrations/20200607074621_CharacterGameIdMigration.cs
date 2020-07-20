using Microsoft.EntityFrameworkCore.Migrations;

namespace LaDanse.Persistence.Migrations
{
    public partial class CharacterGameIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "gameId",
                table: "GameCharacter",
                type: "INT UNSIGNED",
                nullable: false,
                defaultValue: 0u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gameId",
                table: "GameCharacter");
        }
    }
}