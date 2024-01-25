using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _mig_Fixx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Groups_BlogGroups_BlogGroupId1",
                table: "Blog_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Groups_Blogs_BlogId1",
                table: "Blog_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId1",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId1",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permissions_Permissions_PermissionId1",
                table: "Role_Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permissions_Roles_RoleId1",
                table: "Role_Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Galleries_ImageId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId1",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Users_UserId1",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_NotificationId1",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_UserId1",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Services_ImageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Role_Permissions_PermissionId1",
                table: "Role_Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Role_Permissions_RoleId1",
                table: "Role_Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderId1",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId1",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_Blog_Groups_BlogGroupId1",
                table: "Blog_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Blog_Groups_BlogId1",
                table: "Blog_Groups");

            migrationBuilder.DropColumn(
                name: "NotificationId1",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserNotifications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PermissionId1",
                table: "Role_Permissions");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Role_Permissions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogGroupId1",
                table: "Blog_Groups");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "Blog_Groups");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserNotifications",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "NotificationId",
                table: "UserNotifications",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionId",
                table: "User_Plans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "Role_Permissions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PermissionId",
                table: "Role_Permissions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "OrderLines",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "OrderLines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BlogId",
                table: "Blog_Groups",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "BlogGroupId",
                table: "Blog_Groups",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PlanFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanPlanFeature",
                columns: table => new
                {
                    PlansId = table.Column<long>(type: "bigint", nullable: false),
                    planFeaturesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanPlanFeature", x => new { x.PlansId, x.planFeaturesId });
                    table.ForeignKey(
                        name: "FK_PlanPlanFeature_PlanFeatures_planFeaturesId",
                        column: x => x.planFeaturesId,
                        principalTable: "PlanFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanPlanFeature_Plans_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_PermissionId",
                table: "Role_Permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_RoleId",
                table: "Role_Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Groups_BlogGroupId",
                table: "Blog_Groups",
                column: "BlogGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Groups_BlogId",
                table: "Blog_Groups",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanPlanFeature_planFeaturesId",
                table: "PlanPlanFeature",
                column: "planFeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Groups_BlogGroups_BlogGroupId",
                table: "Blog_Groups",
                column: "BlogGroupId",
                principalTable: "BlogGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Groups_Blogs_BlogId",
                table: "Blog_Groups",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permissions_Permissions_PermissionId",
                table: "Role_Permissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permissions_Roles_RoleId",
                table: "Role_Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Groups_BlogGroups_BlogGroupId",
                table: "Blog_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Groups_Blogs_BlogId",
                table: "Blog_Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permissions_Permissions_PermissionId",
                table: "Role_Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permissions_Roles_RoleId",
                table: "Role_Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Users_UserId",
                table: "UserNotifications");

            migrationBuilder.DropTable(
                name: "PlanPlanFeature");

            migrationBuilder.DropTable(
                name: "PlanFeatures");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Role_Permissions_PermissionId",
                table: "Role_Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Role_Permissions_RoleId",
                table: "Role_Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_Blog_Groups_BlogGroupId",
                table: "Blog_Groups");

            migrationBuilder.DropIndex(
                name: "IX_Blog_Groups_BlogId",
                table: "Blog_Groups");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationId",
                table: "UserNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "NotificationId1",
                table: "UserNotifications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "UserNotifications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "User_Plans",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ImageId",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Role_Permissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PermissionId",
                table: "Role_Permissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PermissionId1",
                table: "Role_Permissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                table: "Role_Permissions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "OrderId1",
                table: "OrderLines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductId1",
                table: "OrderLines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Blog_Groups",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlogGroupId",
                table: "Blog_Groups",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "BlogGroupId1",
                table: "Blog_Groups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BlogId1",
                table: "Blog_Groups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId1",
                table: "UserNotifications",
                column: "NotificationId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId1",
                table: "UserNotifications",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId1",
                table: "Transactions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageId",
                table: "Services",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_PermissionId1",
                table: "Role_Permissions",
                column: "PermissionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_RoleId1",
                table: "Role_Permissions",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId1",
                table: "OrderLines",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId1",
                table: "OrderLines",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Groups_BlogGroupId1",
                table: "Blog_Groups",
                column: "BlogGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Groups_BlogId1",
                table: "Blog_Groups",
                column: "BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Groups_BlogGroups_BlogGroupId1",
                table: "Blog_Groups",
                column: "BlogGroupId1",
                principalTable: "BlogGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Groups_Blogs_BlogId1",
                table: "Blog_Groups",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId1",
                table: "OrderLines",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId1",
                table: "OrderLines",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId1",
                table: "Orders",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permissions_Permissions_PermissionId1",
                table: "Role_Permissions",
                column: "PermissionId1",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permissions_Roles_RoleId1",
                table: "Role_Permissions",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Galleries_ImageId",
                table: "Services",
                column: "ImageId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId1",
                table: "Transactions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId1",
                table: "UserNotifications",
                column: "NotificationId1",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Users_UserId1",
                table: "UserNotifications",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
