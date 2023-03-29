using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LessonDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    ExerciseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Variables = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TranslateExercise_Question = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UseBlocks = table.Column<bool>(type: "bit", nullable: true),
                    TextBlocks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TextToSay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lesson",
                columns: new[] { "Id", "LessonDescription", "LessonName" },
                values: new object[,]
                {
                    { 1, "it is first lesson", "lesson1" },
                    { 2, "it is second lesson", "lesson2" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsEmailConfirmed", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "Bender03@gmail.com", true, "BenderRobot", "qwerty01" },
                    { 2, "JackD@gmail.com", true, "Jack", "qwerty02" }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Answer", "ExerciseType", "IsComplete", "LessonId", "Name", "Question", "Variables" },
                values: new object[,]
                {
                    { 1, "Have", "Grammar", false, 1, "Choose right verb", "_ done your homework?", "[\"Have\",\"Has\",\"Had\"]" },
                    { 2, "Went", "Grammar", false, 2, "Choose right verb", "Last month I _ to Scotland on holiday.", "[\"Go\",\"Went\"]" }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Answer", "ExerciseType", "IsComplete", "LessonId", "Name", "TranslateExercise_Question", "TextBlocks", "UseBlocks" },
                values: new object[,]
                {
                    { 3, "You ate yesterday?", "Translate", false, 1, "Translate sentence", "Ти їв вчора?", "[\"You\",\"ate\",\"yesterday?\"]", true },
                    { 4, "Ти їв учора?", "Translate", false, 2, "Translate sentence", "You ate yesterday?", "[]", false }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Answer", "ExerciseType", "IsComplete", "LessonId", "Name", "TextToSay" },
                values: new object[,]
                {
                    { 5, "Ти їв учора?", "Voice", false, 1, "Translate sentence", "You ate yesterday" },
                    { 6, "You ate yesterday", "Voice", false, 2, "Translate sentence", "Ти їв учора?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_LessonId",
                table: "Exercise",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Lesson");
        }
    }
}
