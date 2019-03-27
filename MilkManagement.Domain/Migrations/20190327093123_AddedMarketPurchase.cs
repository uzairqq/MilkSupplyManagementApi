using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedMarketPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Total = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_MarketPurchase_MarketSupplierId",
                table: "MarketPurchase",
                column: "MarketSupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketPurchase");
        }
    }
}
