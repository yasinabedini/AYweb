using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _MIg_UpdateRoleUSers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_Roles_RoleId1",
                table: "Role_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_Users_UserId1",
                table: "Role_Users");

            migrationBuilder.DropIndex(
                name: "IX_Role_Users_RoleId1",
                table: "Role_Users");

            migrationBuilder.DropIndex(
                name: "IX_Role_Users_UserId1",
                table: "Role_Users");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Role_Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Role_Users");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Role_Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "Role_Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Users_RoleId",
                table: "Role_Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Users_UserId",
                table: "Role_Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_Roles_RoleId",
                table: "Role_Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_Users_UserId",
                table: "Role_Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_Roles_RoleId",
                table: "Role_Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Users_Users_UserId",
                table: "Role_Users");

            migrationBuilder.DropIndex(
                name: "IX_Role_Users_RoleId",
                table: "Role_Users");

            migrationBuilder.DropIndex(
                name: "IX_Role_Users_UserId",
                table: "Role_Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Role_Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Role_Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                table: "Role_Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Role_Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Users_RoleId1",
                table: "Role_Users",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Users_UserId1",
                table: "Role_Users",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_Roles_RoleId1",
                table: "Role_Users",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Users_Users_UserId1",
                table: "Role_Users",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
