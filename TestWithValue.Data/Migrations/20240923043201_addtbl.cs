using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestWithValue.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinScore = table.Column<int>(type: "int", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerScore = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Answers_Tbl_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Tbl_Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Answers_Tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Categories",
                columns: new[] { "CategoryId", "MaxScore", "MinScore", "Name" },
                values: new object[,]
                {
                    { 1, 100, 90, "ایده‌آل‌گرا" },
                    { 2, 89, 70, "واقع‌گرا" },
                    { 3, 69, 50, "عمل‌گرا" },
                    { 4, 49, 30, "لذت‌گرا" },
                    { 5, 29, 10, "ایثارگر" },
                    { 6, 9, 0, "فردگرا" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Answers_QuestionId",
                table: "Tbl_Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Answers_UserId",
                table: "Tbl_Answers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Answers");

            migrationBuilder.DropTable(
                name: "Tbl_Categories");

            migrationBuilder.DropTable(
                name: "Tbl_Questions");

            migrationBuilder.DropTable(
                name: "Tbl_Users");
        }
    }
}
