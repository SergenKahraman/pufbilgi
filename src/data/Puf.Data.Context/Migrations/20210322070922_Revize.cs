using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Puf.Data.Context.Migrations
{
    public partial class Revize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleExams",
                schema: "Categorization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false),
                    ExamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleExams_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "Content",
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalSchema: "Categorization",
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleExams_ArticleId",
                schema: "Categorization",
                table: "ArticleExams",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleExams_ExamId",
                schema: "Categorization",
                table: "ArticleExams",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleExams",
                schema: "Categorization");
        }
    }
}
