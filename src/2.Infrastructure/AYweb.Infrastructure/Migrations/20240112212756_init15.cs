using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AYweb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId1",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Forwards_ForwardId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ForwardId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ForwardId1",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "OrderId1",
                table: "OrderLines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OrderId",
                table: "Forwards",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Forwards_OrderId",
                table: "Forwards",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forwards_Orders_OrderId",
                table: "Forwards",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId1",
                table: "OrderLines",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forwards_Orders_OrderId",
                table: "Forwards");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderId1",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_Forwards_OrderId",
                table: "Forwards");

            migrationBuilder.AddColumn<long>(
                name: "ForwardId1",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OrderId1",
                table: "OrderLines",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Forwards",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ForwardId1",
                table: "Orders",
                column: "ForwardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderId1",
                table: "OrderLines",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Forwards_ForwardId1",
                table: "Orders",
                column: "ForwardId1",
                principalTable: "Forwards",
                principalColumn: "Id");
        }
    }
}
