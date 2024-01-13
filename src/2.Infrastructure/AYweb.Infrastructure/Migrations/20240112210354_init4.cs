using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Gallery_ImageId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gallery",
                table: "Gallery");

            migrationBuilder.RenameTable(
                name: "Gallery",
                newName: "Galleries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Galleries_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Galleries_ImageId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries");

            migrationBuilder.RenameTable(
                name: "Galleries",
                newName: "Gallery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gallery",
                table: "Gallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Gallery_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Gallery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
