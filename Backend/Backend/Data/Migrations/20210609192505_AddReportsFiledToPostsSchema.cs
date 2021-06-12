using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class AddReportsFiledToPostsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reports",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 9, 21, 25, 4, 469, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 9, 21, 25, 4, 475, DateTimeKind.Local).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 6, 9, 21, 25, 4, 475, DateTimeKind.Local).AddTicks(2092));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reports",
                table: "Posts");

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
    }
}
