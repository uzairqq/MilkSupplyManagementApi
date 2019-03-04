using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedCustomerSupplied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSupplied",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MorningSupply = table.Column<string>(nullable: true),
                    AfternoonSupply = table.Column<string>(nullable: true),
                    MorningAmount = table.Column<double>(nullable: false),
                    AfternoonAmount = table.Column<double>(nullable: false),
                    Rate = table.Column<float>(nullable: true),
                    Debit = table.Column<float>(nullable: true),
                    Credit = table.Column<float>(nullable: true),
                    Total = table.Column<double>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    LastUpdatedById = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerId",
                table: "CustomerSupplied",
                column: "CustomerRatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSupplied");
        }
    }
}
