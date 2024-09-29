using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWithValue.Data.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
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
                    table.PrimaryKey("PK_tbl_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_tbl_Questions_tbl_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "tbl_Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_tbl_Topics_tbl_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "tbl_Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_tbl_Options_tbl_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tbl_Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Options_tbl_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "tbl_Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerValue = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_tbl_Answers_tbl_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "tbl_Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Answers_tbl_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tbl_Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Answers_tbl_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "tbl_Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Answers_tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answers_OptionId",
                table: "tbl_Answers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answers_QuestionId",
                table: "tbl_Answers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answers_TestId",
                table: "tbl_Answers",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answers_UserId",
                table: "tbl_Answers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Options_QuestionId",
                table: "tbl_Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Options_TestId",
                table: "tbl_Options",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Questions_TestId",
                table: "tbl_Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Topics_TestId",
                table: "tbl_Topics",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Answers");

            migrationBuilder.DropTable(
                name: "tbl_Topics");

            migrationBuilder.DropTable(
                name: "tbl_Options");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tbl_Questions");

            migrationBuilder.DropTable(
                name: "tbl_Tests");
        }
    }
}
