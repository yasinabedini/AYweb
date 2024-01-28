using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _Mig_ProjectUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Projects_ProjectId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_ProjectId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Galleries");

            migrationBuilder.AddColumn<string>(
                name: "FirstImage",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondImage",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstImage",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SecondImage",
                table: "Projects");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "Galleries",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_ProjectId",
                table: "Galleries",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Projects_ProjectId",
                table: "Galleries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
