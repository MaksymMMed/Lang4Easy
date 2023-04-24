using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTextBlocksFromTranslateExerciseAndAddTypeOfExerciseForVoiceExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextBlocks",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "UseBlocks",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Exercise",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "Listen");

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "TextToSay", "Type" },
                values: new object[] { "You ate yesterday", "Repeat" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "TextBlocks",
                table: "Exercise",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseBlocks",
                table: "Exercise",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TextBlocks", "UseBlocks" },
                values: new object[] { "[\"You\",\"ate\",\"yesterday?\"]", true });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TextBlocks", "UseBlocks" },
                values: new object[] { "[]", false });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6,
                column: "TextToSay",
                value: "Ти їв учора?");
        }
    }
}
