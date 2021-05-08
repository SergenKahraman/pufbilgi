using Microsoft.EntityFrameworkCore.Migrations;

namespace Puf.Data.Context.Migrations
{
    public partial class writerrevize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "Management",
                table: "Writers",
                maxLength: 24,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "Management",
                table: "Writers");
        }
    }
}
