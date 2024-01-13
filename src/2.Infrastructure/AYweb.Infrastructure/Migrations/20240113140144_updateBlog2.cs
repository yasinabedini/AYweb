using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateBlog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BlogId",
                table: "Galleries",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_BlogId",
                table: "Galleries",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Blogs_BlogId",
                table: "Galleries",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Blogs_BlogId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_BlogId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Galleries");
        }
    }
}
