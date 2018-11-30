using Microsoft.EntityFrameworkCore.Migrations;

namespace Bingo_CSD_412.Migrations
{
    public partial class AddCategoryToWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Words",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Words");
        }
    }
}
