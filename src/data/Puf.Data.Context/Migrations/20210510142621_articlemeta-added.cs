using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Puf.Data.Context.Migrations
{
    public partial class articlemetaadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleMeta",
                schema: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(maxLength: 400, nullable: false),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    PreViewPhotoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleMeta_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "Content",
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleMeta_Documents_PreViewPhotoId",
                        column: x => x.PreViewPhotoId,
                        principalSchema: "Management",
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleMeta_ArticleId",
                schema: "Content",
                table: "ArticleMeta",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleMeta_PreViewPhotoId",
                schema: "Content",
                table: "ArticleMeta",
                column: "PreViewPhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleMeta",
                schema: "Content");
        }
    }
}
