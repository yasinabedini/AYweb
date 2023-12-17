using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Web.Migrations
{
    /// <inheritdoc />
    public partial class _Mig_UpdateProjectEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Projects",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Projects",
                newName: "Name");
        }
    }
}
