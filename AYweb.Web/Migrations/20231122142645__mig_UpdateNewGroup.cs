using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Web.Migrations
{
    /// <inheritdoc />
    public partial class _mig_UpdateNewGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsGroups_NewsGroups_NewsGroupId",
                table: "NewsGroups");

            migrationBuilder.DropIndex(
                name: "IX_NewsGroups_NewsGroupId",
                table: "NewsGroups");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "NewsGroupId",
                table: "NewsGroups");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "User_name",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User_phoneNumber",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Users_UserId",
                table: "News",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Users_UserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_UserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "News");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "User_name",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "User_phoneNumber",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "NewsGroupId",
                table: "NewsGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NewsGroups_NewsGroupId",
                table: "NewsGroups",
                column: "NewsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsGroups_NewsGroups_NewsGroupId",
                table: "NewsGroups",
                column: "NewsGroupId",
                principalTable: "NewsGroups",
                principalColumn: "Id");
        }
    }
}
