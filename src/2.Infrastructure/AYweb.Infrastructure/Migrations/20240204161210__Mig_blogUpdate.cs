using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _Mig_blogUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Blogs_BlogId1",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_BlogId1",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "BlogComments");

            migrationBuilder.AlterColumn<long>(
                name: "BlogId",
                table: "BlogComments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BlogId1",
                table: "BlogComments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId1",
                table: "BlogComments",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Blogs_BlogId1",
                table: "BlogComments",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
