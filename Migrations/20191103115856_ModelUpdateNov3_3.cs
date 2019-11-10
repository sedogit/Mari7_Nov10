using Microsoft.EntityFrameworkCore.Migrations;

namespace Mari7.Migrations
{
    public partial class ModelUpdateNov3_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSteps_MariUsers_UserID1",
                table: "OrderSteps");

            migrationBuilder.DropIndex(
                name: "IX_OrderSteps_UserID1",
                table: "OrderSteps");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "OrderSteps");

            migrationBuilder.AlterColumn<long>(
                name: "UserID",
                table: "OrderSteps",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSteps_UserID",
                table: "OrderSteps",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSteps_MariUsers_UserID",
                table: "OrderSteps",
                column: "UserID",
                principalTable: "MariUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSteps_MariUsers_UserID",
                table: "OrderSteps");

            migrationBuilder.DropIndex(
                name: "IX_OrderSteps_UserID",
                table: "OrderSteps");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "OrderSteps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UserID1",
                table: "OrderSteps",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderSteps_UserID1",
                table: "OrderSteps",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSteps_MariUsers_UserID1",
                table: "OrderSteps",
                column: "UserID1",
                principalTable: "MariUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
