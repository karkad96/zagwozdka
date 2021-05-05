using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class AddAdditionalFieldsInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExtraInfo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramingLanguage",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 4, 14, 11, 59, 726, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 4, 14, 11, 59, 732, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 4, 14, 11, 59, 732, DateTimeKind.Local).AddTicks(360));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraInfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProgramingLanguage",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 26, 17, 23, 2, 364, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 26, 17, 23, 2, 369, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 26, 17, 23, 2, 369, DateTimeKind.Local).AddTicks(2626));
        }
    }
}
