using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Puf.Data.Context.Migrations
{
    public partial class Revize2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialTypes_Documents_DocumentId",
                schema: "Management",
                table: "SocialTypes");

            migrationBuilder.DropIndex(
                name: "IX_SocialTypes_DocumentId",
                schema: "Management",
                table: "SocialTypes");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                schema: "Management",
                table: "SocialTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                schema: "Management",
                table: "SocialTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SocialTypes_DocumentId",
                schema: "Management",
                table: "SocialTypes",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialTypes_Documents_DocumentId",
                schema: "Management",
                table: "SocialTypes",
                column: "DocumentId",
                principalSchema: "Management",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
