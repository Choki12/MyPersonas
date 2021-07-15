using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPersonasBackEnd.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(maxLength: 500, nullable: false),
                    State = table.Column<string>(maxLength: 500, nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    DateTaken = table.Column<DateTime>(nullable: true),
                    TestState = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TesteeTest",
                columns: table => new
                {
                    TesteeId = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Surname = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(maxLength: 400, nullable: true),
                    DOB = table.Column<string>(maxLength: 400, nullable: true),
                    UserName = table.Column<string>(maxLength: 400, nullable: true),
                    Attempts = table.Column<int>(nullable: false),
                    LastDateTaken = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesteeTest", x => new { x.TesteeId, x.TestId });
                    table.ForeignKey(
                        name: "FK_TesteeTest_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TesteeTest_Testees_TesteeId",
                        column: x => x.TesteeId,
                        principalTable: "Testees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestion",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Question = table.Column<string>(maxLength: 500, nullable: false),
                    State = table.Column<string>(maxLength: 500, nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(maxLength: 500, nullable: false),
                    QuestionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestion", x => new { x.TestId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_TestQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestQuestion_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testees_UserName",
                table: "Testees",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TesteeTest_TestId",
                table: "TesteeTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestion_QuestionsId",
                table: "TestQuestion",
                column: "QuestionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TesteeTest");

            migrationBuilder.DropTable(
                name: "TestQuestion");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Testees_UserName",
                table: "Testees");
        }
    }
}
