using Microsoft.EntityFrameworkCore.Migrations;

namespace Mari7.Migrations
{
    public partial class ModelUpdateNov3_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_MariUsers_UserID1",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserID1",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "UserRoles");

            migrationBuilder.AlterColumn<long>(
                name: "UserID",
                table: "UserRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_MariUsers_UserID",
                table: "UserRoles",
                column: "UserID",
                principalTable: "MariUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_MariUsers_UserID",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserRoles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UserID1",
                table: "UserRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID1",
                table: "UserRoles",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_MariUsers_UserID1",
                table: "UserRoles",
                column: "UserID1",
                principalTable: "MariUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
