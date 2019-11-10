using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mari7.Migrations
{
    public partial class ModelUpdateNov3_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepRoles_MariRoles_RoleID",
                table: "StepRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_StepRoles_OrderSteps_StepID1",
                table: "StepRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_MariRoles_RoleID",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_StepRoles_StepID1",
                table: "StepRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSteps",
                table: "OrderSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MariRoles",
                table: "MariRoles");

            migrationBuilder.DropColumn(
                name: "StepID1",
                table: "StepRoles");

            migrationBuilder.AlterColumn<int>(
                name: "StepID",
                table: "OrderSteps",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "OrderSteps",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "MariRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "MariRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSteps",
                table: "OrderSteps",
                column: "StepID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MariRoles",
                table: "MariRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_StepRoles_StepID",
                table: "StepRoles",
                column: "StepID");

            migrationBuilder.AddForeignKey(
                name: "FK_StepRoles_MariRoles_RoleID",
                table: "StepRoles",
                column: "RoleID",
                principalTable: "MariRoles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepRoles_OrderSteps_StepID",
                table: "StepRoles",
                column: "StepID",
                principalTable: "OrderSteps",
                principalColumn: "StepID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_MariRoles_RoleID",
                table: "UserRoles",
                column: "RoleID",
                principalTable: "MariRoles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepRoles_MariRoles_RoleID",
                table: "StepRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_StepRoles_OrderSteps_StepID",
                table: "StepRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_MariRoles_RoleID",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_StepRoles_StepID",
                table: "StepRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSteps",
                table: "OrderSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MariRoles",
                table: "MariRoles");

            migrationBuilder.AddColumn<long>(
                name: "StepID1",
                table: "StepRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "OrderSteps",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "StepID",
                table: "OrderSteps",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "MariRoles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "MariRoles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSteps",
                table: "OrderSteps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MariRoles",
                table: "MariRoles",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_StepRoles_StepID1",
                table: "StepRoles",
                column: "StepID1");

            migrationBuilder.AddForeignKey(
                name: "FK_StepRoles_MariRoles_RoleID",
                table: "StepRoles",
                column: "RoleID",
                principalTable: "MariRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepRoles_OrderSteps_StepID1",
                table: "StepRoles",
                column: "StepID1",
                principalTable: "OrderSteps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_MariRoles_RoleID",
                table: "UserRoles",
                column: "RoleID",
                principalTable: "MariRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
