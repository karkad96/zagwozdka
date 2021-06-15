using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class AddNewSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProblemTags",
                keyColumns: new[] { "ProblemId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProblemTags",
                keyColumns: new[] { "ProblemId", "TagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProblemTags",
                keyColumns: new[] { "ProblemId", "TagId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProblemTags",
                keyColumns: new[] { "ProblemId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProblemTags",
                keyColumns: new[] { "ProblemId", "TagId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProblemTags",
                keyColumns: new[] { "ProblemId", "TagId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                columns: new[] { "Answer", "Description", "Difficulty", "ReleaseDate", "Title" },
                values: new object[] { "233168", "", 5, new DateTime(2021, 6, 14, 19, 35, 40, 139, DateTimeKind.Local).AddTicks(7558), "Wielokrotność 3 i 5" });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                columns: new[] { "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { "4613732", "Każdy nowy wyraz w ciągu Fibonacciego jest generowany przez dodanie dwóch poprzednich wyrazów. Zaczynając od 1 i 2, pierwsze 10 terminów będzie:\n1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\nRozważając wyrazy w ciągu Fibonacciego, których wartości nie przekraczają czterech milionów, znajdź sumę wyrazów o parzystych wartościach.", 5, new DateTime(2021, 6, 14, 19, 35, 40, 145, DateTimeKind.Local).AddTicks(2647), 101, "Parzyste liczby Fibonacciego" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "TagName",
                value: "Programowanie");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "TagName",
                value: "Programowanie Dynamiczne");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "TagName",
                value: "Jednolinijkowiec");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 6, "Drzewa binarne" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                columns: new[] { "Answer", "Description", "Difficulty", "ReleaseDate", "Title" },
                values: new object[] { "128754612", "Test 1", 10, new DateTime(2021, 6, 9, 21, 25, 4, 469, DateTimeKind.Local).AddTicks(5891), "Problem 1" });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                columns: new[] { "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { "5272", "Test 2", 30, new DateTime(2021, 6, 9, 21, 25, 4, 475, DateTimeKind.Local).AddTicks(1827), 52, "Problem 2" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "ProblemId", "Answer", "Description", "Difficulty", "ReleaseDate", "SolvedBy", "Title" },
                values: new object[] { 3, "234677892", "Test 3", 70, new DateTime(2021, 6, 9, 21, 25, 4, 475, DateTimeKind.Local).AddTicks(2092), 12, "Problem 3" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "TagName",
                value: "Drzewo binarne");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "TagName",
                value: "Programowanie");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "TagName",
                value: "Programowanie Dynamiczne");

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 3, 1 });
        }
    }
}
