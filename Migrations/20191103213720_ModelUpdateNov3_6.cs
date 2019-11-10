using Microsoft.EntityFrameworkCore.Migrations;

namespace Mari7.Migrations
{
    public partial class ModelUpdateNov3_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "MariUsers");

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "UserRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "UserRoles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateDate",
                table: "UserRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "UserRoles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Suppliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "Suppliers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "StepRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "StepRoles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateDate",
                table: "StepRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "StepRoles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "ProductPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "OrderSteps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "MariUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "MariUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateDate",
                table: "MariUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "MariUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "MariRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InsertUser",
                table: "MariRoles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateDate",
                table: "MariRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "MariRoles",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertDate",
                table: "Currencies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "StepRoles");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "StepRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "StepRoles");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "StepRoles");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ProductPrices");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "OrderSteps");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "MariUsers");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "MariUsers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "MariUsers");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "MariUsers");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "MariRoles");

            migrationBuilder.DropColumn(
                name: "InsertUser",
                table: "MariRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "MariRoles");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "MariRoles");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Currencies");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "MariUsers",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
