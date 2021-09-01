using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesCG.Migrations
{
    public partial class TimesPlayed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesPlayed",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimesPlayed",
                table: "Character");
        }
    }
}
