using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iqra_Quran_Center.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_QuestionPaper_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionPaper_Exams_ExamId",
                table: "QuestionPaper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionPaper",
                table: "QuestionPaper");

            migrationBuilder.RenameTable(
                name: "QuestionPaper",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionPaper_ExamId",
                table: "Questions",
                newName: "IX_Questions_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuestionPaper");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExamId",
                table: "QuestionPaper",
                newName: "IX_QuestionPaper_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionPaper",
                table: "QuestionPaper",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_QuestionPaper_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "QuestionPaper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionPaper_Exams_ExamId",
                table: "QuestionPaper",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
