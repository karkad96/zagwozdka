using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class AddProblemTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Problems_ProblemId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProblemId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ProblemId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "ProblemTags",
                columns: table => new
                {
                    ProblemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTags", x => new { x.ProblemId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProblemTags_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "ProblemTags",
                columns: new[] { "ProblemId", "TagId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 21, 18, 35, 13, 752, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 21, 18, 35, 13, 757, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 21, 18, 35, 13, 757, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                column: "TagName",
                value: "Drzewo binarne");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemTags_TagId",
                table: "ProblemTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemTags");

            migrationBuilder.AddColumn<int>(
                name: "ProblemId",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 17, 16, 11, 8, 864, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 17, 16, 11, 8, 869, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 4, 17, 16, 11, 8, 869, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 1,
                column: "ProblemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 2,
                columns: new[] { "ProblemId", "TagName" },
                values: new object[] { 1, "Programowanie" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 3,
                column: "ProblemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 4,
                column: "ProblemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 5,
                column: "ProblemId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProblemId",
                table: "Tags",
                column: "ProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Problems_ProblemId",
                table: "Tags",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
