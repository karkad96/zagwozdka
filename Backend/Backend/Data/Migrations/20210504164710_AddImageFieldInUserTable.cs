using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class AddImageFieldInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 4, 18, 47, 10, 336, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 4, 18, 47, 10, 341, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 4, 18, 47, 10, 341, DateTimeKind.Local).AddTicks(3436));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

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
    }
}
