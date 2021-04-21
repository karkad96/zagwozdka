using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class SeedDataForProblems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 1, "128754612", "Test 1", "Łatwy", new DateTime(2021, 4, 17, 16, 11, 8, 864, DateTimeKind.Local).AddTicks(4050), 112, "Problem 1" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 2, "5272", "Test 2", "Normalny", new DateTime(2021, 4, 17, 16, 11, 8, 869, DateTimeKind.Local).AddTicks(1818), 52, "Problem 2" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 3, "234677892", "Test 3", "Trudny", new DateTime(2021, 4, 17, 16, 11, 8, 869, DateTimeKind.Local).AddTicks(1974), 12, "Problem 3" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "ProblemId", "TagName" },
                values: new object[] { 1, 1, "Matematyka" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "ProblemId", "TagName" },
                values: new object[] { 2, 1, "Programowanie" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "ProblemId", "TagName" },
                values: new object[] { 3, 2, "Programowanie" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "ProblemId", "TagName" },
                values: new object[] { 4, 2, "Fizyka" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "ProblemId", "TagName" },
                values: new object[] { 5, 3, "Programowanie Dynamiczne" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3);
        }
    }
}
