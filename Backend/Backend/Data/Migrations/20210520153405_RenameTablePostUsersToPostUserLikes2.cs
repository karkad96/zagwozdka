using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Data.Migrations
{
    public partial class RenameTablePostUsersToPostUserLikes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostUsers_AspNetUsers_UserId",
                table: "PostUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUsers_Posts_PostId",
                table: "PostUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostUsers",
                table: "PostUsers");

            migrationBuilder.RenameTable(
                name: "PostUsers",
                newName: "PostUserLikes");

            migrationBuilder.RenameIndex(
                name: "IX_PostUsers_UserId",
                table: "PostUserLikes",
                newName: "IX_PostUserLikes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostUserLikes",
                table: "PostUserLikes",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 20, 17, 34, 4, 847, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 20, 17, 34, 4, 851, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 20, 17, 34, 4, 852, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserLikes_AspNetUsers_UserId",
                table: "PostUserLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUserLikes_Posts_PostId",
                table: "PostUserLikes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostUserLikes_AspNetUsers_UserId",
                table: "PostUserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUserLikes_Posts_PostId",
                table: "PostUserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostUserLikes",
                table: "PostUserLikes");

            migrationBuilder.RenameTable(
                name: "PostUserLikes",
                newName: "PostUsers");

            migrationBuilder.RenameIndex(
                name: "IX_PostUserLikes_UserId",
                table: "PostUsers",
                newName: "IX_PostUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostUsers",
                table: "PostUsers",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 20, 17, 32, 11, 890, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 2,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 20, 17, 32, 11, 895, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "Problems",
                keyColumn: "ProblemId",
                keyValue: 3,
                column: "ReleaseDate",
                value: new DateTime(2021, 5, 20, 17, 32, 11, 895, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.AddForeignKey(
                name: "FK_PostUsers_AspNetUsers_UserId",
                table: "PostUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUsers_Posts_PostId",
                table: "PostUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
