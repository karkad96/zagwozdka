using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class ChangeDefaultValueOfSolvedDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 3, 21, 14, 39, 808, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 3, 21, 14, 39, 814, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 3, 21, 14, 39, 814, DateTimeKind.Local).AddTicks(5234));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 3, 20, 37, 17, 934, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 3, 20, 37, 17, 939, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 3, 20, 37, 17, 939, DateTimeKind.Local).AddTicks(9557));
        }
    }
}
