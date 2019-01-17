using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class Misc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied");

            migrationBuilder.DropIndex(
                name: "IX_CustomerSupplied_CustomerTypeId",
                table: "CustomerSupplied");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                table: "CustomerSupplied");

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
                table: "CustomerSupplied",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedById",
                table: "CustomerSupplied",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                table: "CustomerSupplied",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedById",
                table: "CustomerSupplied",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                table: "CustomerSupplied",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
