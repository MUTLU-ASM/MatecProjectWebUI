using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_update_tables_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductPrices");

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "ProductStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "ProductPrices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_UnitTypeId",
                table: "ProductStocks",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_UnitType_UnitTypeId",
                table: "ProductStocks",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_UnitType_UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.DropIndex(
                name: "IX_ProductStocks_UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "ProductPrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "ProductPrices",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
