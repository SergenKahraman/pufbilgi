using Microsoft.EntityFrameworkCore.Migrations;

namespace Puf.Data.Context.Migrations
{
    public partial class revizewriter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailAddress",
                schema: "Management",
                table: "Writers");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "Management",
                table: "Writers",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                schema: "Management",
                table: "Writers",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "Management",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                schema: "Management",
                table: "Writers");

            migrationBuilder.AddColumn<string>(
                name: "MailAddress",
                schema: "Management",
                table: "Writers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
