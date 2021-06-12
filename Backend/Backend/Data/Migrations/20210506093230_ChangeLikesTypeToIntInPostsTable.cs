using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class ChangeLikesTypeToIntInPostsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Likes",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 6, 11, 32, 30, 340, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 6, 11, 32, 30, 345, DateTimeKind.Local).AddTicks(7353));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 6, 11, 32, 30, 345, DateTimeKind.Local).AddTicks(7519));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Likes",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 5, 19, 22, 13, 51, DateTimeKind.Local).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 5, 19, 22, 13, 56, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 5, 19, 22, 13, 56, DateTimeKind.Local).AddTicks(8525));
        }
    }
}
