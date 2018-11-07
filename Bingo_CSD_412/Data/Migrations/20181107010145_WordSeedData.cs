using Microsoft.EntityFrameworkCore.Migrations;

namespace Bingo_CSD_412.Data.Migrations
{
    public partial class WordSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Definition", "Entry" },
                values: new object[] { 1, "A programming language", "C#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
