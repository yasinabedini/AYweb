using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _MIg_updatePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentId1",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ParentId1",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ParentId1",
                table: "Permissions");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Permissions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId",
                principalTable: "Permissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Permissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentId1",
                table: "Permissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId1",
                table: "Permissions",
                column: "ParentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParentId1",
                table: "Permissions",
                column: "ParentId1",
                principalTable: "Permissions",
                principalColumn: "Id");
        }
    }
}
