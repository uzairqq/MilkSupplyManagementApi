﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    public partial class SeedCustomerTpe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    ExpenseName = table.Column<string>(maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MarketSupplierName = table.Column<string>(maxLength: 100, nullable: false),
                    MarketSupplierAddress = table.Column<string>(maxLength: 150, nullable: false),
                    MarketSupplierContact = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSupplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SupplierName = table.Column<string>(maxLength: 255, nullable: false),
                    SupplierContact = table.Column<string>(maxLength: 1025, nullable: true),
                    SupplierAddress = table.Column<string>(maxLength: 20, nullable: true),
                    IsRateAssignedToSupplier = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Address = table.Column<string>(maxLength: 1025, nullable: true),
                    Contact = table.Column<string>(maxLength: 20, nullable: true),
                    IsRateAssignedToCustomer = table.Column<bool>(nullable: false),
                    CustomerTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyExpense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ExpenseId = table.Column<int>(nullable: false),
                    Rate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyExpense_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MarketSupplierId = table.Column<int>(nullable: false),
                    MorningPurchase = table.Column<string>(nullable: true),
                    MorningRate = table.Column<int>(nullable: false),
                    MorningAmount = table.Column<string>(nullable: true),
                    AfternoonPurchase = table.Column<string>(nullable: true),
                    AfternoonRate = table.Column<int>(nullable: false),
                    AfternoonAmount = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<int>(nullable: false),
                    TotalMilk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPurchase_MarketSupplier_MarketSupplierId",
                        column: x => x.MarketSupplierId,
                        principalTable: "MarketSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketSell",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MarketSupplierId = table.Column<int>(nullable: false),
                    MorningSell = table.Column<string>(nullable: true),
                    MorningAmount = table.Column<string>(nullable: true),
                    MorningRate = table.Column<string>(nullable: true),
                    AfternoonSell = table.Column<string>(nullable: true),
                    AfternoonAmount = table.Column<string>(nullable: true),
                    AfternoonRate = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    ComissionRate = table.Column<int>(nullable: false),
                    TotalComission = table.Column<int>(nullable: true),
                    TotalMilk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketSell_MarketSupplier_MarketSupplierId",
                        column: x => x.MarketSupplierId,
                        principalTable: "MarketSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    CurrentRate = table.Column<int>(nullable: false),
                    PreviousRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierRates_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierSupplied",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    MorningPurchase = table.Column<string>(nullable: true),
                    AfternoonPurchase = table.Column<string>(nullable: true),
                    MorningAmount = table.Column<string>(nullable: true),
                    AfternoonAmount = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Total = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierSupplied", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierSupplied_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CurrentRate = table.Column<int>(nullable: false),
                    PreviousRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRates_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSupplied",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerTypeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    MorningSupply = table.Column<string>(nullable: true),
                    AfternoonSupply = table.Column<string>(nullable: true),
                    MorningAmount = table.Column<double>(nullable: false),
                    AfternoonAmount = table.Column<double>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    Debit = table.Column<float>(nullable: true),
                    Credit = table.Column<float>(nullable: true),
                    Total = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSupplied", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSupplied_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "IsDeleted", "LastUpdatedById", "LastUpdatedOn", "Type" },
                values: new object[] { 1, 1, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), false, 1, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), "Daily" });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "IsDeleted", "LastUpdatedById", "LastUpdatedOn", "Type" },
                values: new object[] { 2, 1, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), false, 1, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Local), "Weekly" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRates_CustomerId",
                table: "CustomerRates",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerId",
                table: "CustomerSupplied",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyExpense_ExpenseId",
                table: "DailyExpense",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPurchase_MarketSupplierId",
                table: "MarketPurchase",
                column: "MarketSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketSell_MarketSupplierId",
                table: "MarketSell",
                column: "MarketSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierRates_SupplierId",
                table: "SupplierRates",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierSupplied_SupplierId",
                table: "SupplierSupplied",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRates");

            migrationBuilder.DropTable(
                name: "CustomerSupplied");

            migrationBuilder.DropTable(
                name: "DailyExpense");

            migrationBuilder.DropTable(
                name: "MarketPurchase");

            migrationBuilder.DropTable(
                name: "MarketSell");

            migrationBuilder.DropTable(
                name: "SupplierRates");

            migrationBuilder.DropTable(
                name: "SupplierSupplied");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "MarketSupplier");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
