using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyCompleteExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Exercise");

            migrationBuilder.CreateTable(
                name: "CompleteStatus",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteStatus", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_CompleteStatus_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompleteStatus_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompleteStatus",
                columns: new[] { "ExerciseId", "UserId", "Status" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 1, true },
                    { 3, 1, false },
                    { 4, 1, true },
                    { 5, 1, false },
                    { 6, 1, false },
                    { 1, 2, true },
                    { 2, 2, true },
                    { 3, 2, false },
                    { 4, 2, true },
                    { 5, 2, true },
                    { 6, 2, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompleteStatus_ExerciseId",
                table: "CompleteStatus",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompleteStatus");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Exercise",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsComplete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsComplete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsComplete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsComplete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsComplete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsComplete",
                value: false);
        }
    }
}
