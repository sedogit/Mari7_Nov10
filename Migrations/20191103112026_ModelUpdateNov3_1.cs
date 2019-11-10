using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mari7.Migrations
{
    public partial class ModelUpdateNov3_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    IMONumber = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerFirm = table.Column<string>(maxLength: 250, nullable: true),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<long>(nullable: false),
                    ProductIMPACode = table.Column<string>(maxLength: 250, nullable: true),
                    ProductNameTR = table.Column<string>(maxLength: 250, nullable: true),
                    ProductNameEN = table.Column<string>(maxLength: 250, nullable: true),
                    RequestedQuantity = table.Column<int>(nullable: false),
                    SaleUnitPrice = table.Column<decimal>(nullable: false),
                    SaleTotalPrice = table.Column<decimal>(nullable: false),
                    SupplierName = table.Column<string>(maxLength: 250, nullable: true),
                    SupplierID = table.Column<int>(nullable: false),
                    InvoiceDate = table.Column<int>(nullable: false),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MariRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleID = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: true),
                    RoleDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MariRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MariUsers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Token = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MariUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RFQ = table.Column<string>(maxLength: 100, nullable: true),
                    ETA = table.Column<int>(nullable: false),
                    DeliveryPlace = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerID = table.Column<long>(nullable: false),
                    IMO = table.Column<string>(maxLength: 250, nullable: true),
                    Firm = table.Column<string>(maxLength: 250, nullable: true),
                    CustomerName = table.Column<string>(maxLength: 250, nullable: true),
                    TotalQuantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(maxLength: 20, nullable: true),
                    CurrentUserID = table.Column<long>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    StepID = table.Column<int>(nullable: false),
                    RequestDate = table.Column<int>(nullable: false),
                    CompletionDate = table.Column<int>(nullable: false),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    NameTR = table.Column<string>(maxLength: 100, nullable: true),
                    NameEN = table.Column<string>(maxLength: 100, nullable: true),
                    DescriptionTR = table.Column<string>(maxLength: 1000, nullable: true),
                    DescriptionEN = table.Column<string>(maxLength: 1000, nullable: true),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID1 = table.Column<long>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_MariRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "MariRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_MariUsers_UserID1",
                        column: x => x.UserID1,
                        principalTable: "MariUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderSteps",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepID = table.Column<int>(nullable: false),
                    OrderID = table.Column<long>(nullable: false),
                    UserID1 = table.Column<long>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    StepExplanation = table.Column<string>(maxLength: 500, nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    ActionID = table.Column<int>(nullable: false),
                    ActionUserID = table.Column<int>(nullable: false),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSteps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderSteps_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSteps_MariUsers_UserID1",
                        column: x => x.UserID1,
                        principalTable: "MariUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderID = table.Column<long>(nullable: false),
                    ProductID = table.Column<long>(nullable: false),
                    ProductNameTR = table.Column<string>(maxLength: 250, nullable: true),
                    ProductNameEN = table.Column<string>(maxLength: 250, nullable: true),
                    StockQuantity = table.Column<int>(nullable: false),
                    StockUnitPrice = table.Column<decimal>(nullable: false),
                    PurchaseQuantity = table.Column<int>(nullable: false),
                    RequestedQuantity = table.Column<int>(nullable: false),
                    Size = table.Column<string>(maxLength: 20, nullable: true),
                    PrePurchaseUnitPrice = table.Column<decimal>(nullable: false),
                    PrePurchaseTotalPrice = table.Column<decimal>(nullable: false),
                    PrePurchaseSupplierID = table.Column<long>(nullable: false),
                    PrePurchaseDate = table.Column<int>(nullable: false),
                    PurchaseUnitPrice = table.Column<decimal>(nullable: false),
                    PurchaseTotalPrice = table.Column<decimal>(nullable: false),
                    PurchaseSupplierID = table.Column<long>(nullable: false),
                    PurchaseDate = table.Column<int>(nullable: false),
                    ProfitRate = table.Column<decimal>(nullable: false),
                    SaleOfferUnitPrice = table.Column<decimal>(nullable: false),
                    SaleOfferTotalPrice = table.Column<decimal>(nullable: false),
                    SaleOfferDate = table.Column<int>(nullable: false),
                    SaleApprovalDate = table.Column<int>(nullable: false),
                    ReceiveOperationExpanation = table.Column<string>(maxLength: 1000, nullable: true),
                    ReceiveDate = table.Column<int>(nullable: false),
                    DeliveryOperationExplanation = table.Column<string>(maxLength: 1000, nullable: true),
                    DeliveryDate = table.Column<int>(nullable: false),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Size = table.Column<string>(maxLength: 20, nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    PurchasedFrom = table.Column<string>(maxLength: 250, nullable: true),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductID = table.Column<long>(nullable: false),
                    SupplierID = table.Column<long>(nullable: false),
                    PriceDate = table.Column<int>(nullable: false),
                    MinQuantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Size = table.Column<string>(maxLength: 20, nullable: true),
                    CurrencyID = table.Column<int>(nullable: false),
                    InsertUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateUser = table.Column<string>(maxLength: 100, nullable: true),
                    UpdateDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StepID = table.Column<int>(nullable: false),
                    StepID1 = table.Column<long>(nullable: true),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StepRoles_MariRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "MariRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepRoles_OrderSteps_StepID1",
                        column: x => x.StepID1,
                        principalTable: "OrderSteps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSteps_OrderID",
                table: "OrderSteps",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSteps_UserID1",
                table: "OrderSteps",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_CurrencyID",
                table: "ProductPrices",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductID",
                table: "ProductPrices",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_SupplierID",
                table: "ProductPrices",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_StepRoles_RoleID",
                table: "StepRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_StepRoles_StepID1",
                table: "StepRoles",
                column: "StepID1");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductID",
                table: "Stocks",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID1",
                table: "UserRoles",
                column: "UserID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "StepRoles");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "OrderSteps");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MariRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MariUsers");
        }
    }
}
