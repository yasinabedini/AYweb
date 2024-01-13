using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Permission_ParentId1",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permissions_Permission_PermissionId1",
                table: "Role_Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_ParentId1",
                table: "Permissions",
                newName: "IX_Permissions_ParentId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Permissions_ParentId1",
                table: "Permissions",
                column: "ParentId1",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permissions_Permissions_PermissionId1",
                table: "Role_Permissions",
                column: "PermissionId1",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Permissions_ParentId1",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permissions_Permissions_PermissionId1",
                table: "Role_Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_ParentId1",
                table: "Permission",
                newName: "IX_Permission_ParentId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Permission_ParentId1",
                table: "Permission",
                column: "ParentId1",
                principalTable: "Permission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permissions_Permission_PermissionId1",
                table: "Role_Permissions",
                column: "PermissionId1",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
