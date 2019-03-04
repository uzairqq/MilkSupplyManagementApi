using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSupplied");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "CustomerTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedById",
                table: "CustomerTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "CustomerTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "CustomerRates",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedById",
                table: "CustomerRates",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerRates",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "CustomerTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "CustomerRates",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedById",
                table: "CustomerRates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerRates",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "CustomerSupplied",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AfternoonAmount = table.Column<double>(nullable: false),
                    AfternoonSupply = table.Column<string>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Credit = table.Column<float>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Debit = table.Column<float>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(nullable: true),
                    MorningAmount = table.Column<double>(nullable: false),
                    MorningSupply = table.Column<string>(nullable: true),
                    Rate = table.Column<float>(nullable: true),
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerId",
                table: "CustomerSupplied",
                column: "CustomerRatesId");
        }
    }
}
