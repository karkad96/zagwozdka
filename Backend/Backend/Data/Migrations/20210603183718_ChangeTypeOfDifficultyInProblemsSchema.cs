using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class ChangeTypeOfDifficultyInProblemsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Problems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                columns: new[] { "Difficulty", "ReleaseDate" },
                values: new object[] { 10, new DateTime(2021, 6, 3, 20, 37, 17, 934, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                columns: new[] { "Difficulty", "ReleaseDate" },
                values: new object[] { 30, new DateTime(2021, 6, 3, 20, 37, 17, 939, DateTimeKind.Local).AddTicks(9357) });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                columns: new[] { "Difficulty", "ReleaseDate" },
                values: new object[] { 70, new DateTime(2021, 6, 3, 20, 37, 17, 939, DateTimeKind.Local).AddTicks(9557) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Problems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                columns: new[] { "Difficulty", "ReleaseDate" },
                values: new object[] { "Łatwy", new DateTime(2021, 5, 20, 17, 34, 4, 847, DateTimeKind.Local).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                columns: new[] { "Difficulty", "ReleaseDate" },
                values: new object[] { "Normalny", new DateTime(2021, 5, 20, 17, 34, 4, 851, DateTimeKind.Local).AddTicks(9979) });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                columns: new[] { "Difficulty", "ReleaseDate" },
                values: new object[] { "Trudny", new DateTime(2021, 5, 20, 17, 34, 4, 852, DateTimeKind.Local).AddTicks(135) });
        }
    }
}
