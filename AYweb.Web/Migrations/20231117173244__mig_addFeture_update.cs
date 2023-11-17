using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Web.Migrations
{
    /// <inheritdoc />
    public partial class _mig_addFeture_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Feature");
        }
    }
}
