using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Web.Migrations
{
    /// <inheritdoc />
    public partial class _Mig_updateNews4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "NewsComments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "NewsComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "NewsComments");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NewsComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
