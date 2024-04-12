using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class update_database_unitType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_UnitType_UnitTypeId",
                table: "ProductPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_UnitType_UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitType",
                table: "UnitType");

            migrationBuilder.RenameTable(
                name: "UnitType",
                newName: "unitTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_unitTypes",
                table: "unitTypes",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_unitTypes_UnitTypeId",
                table: "ProductPrices",
                column: "UnitTypeId",
                principalTable: "unitTypes",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_unitTypes_UnitTypeId",
                table: "ProductStocks",
                column: "UnitTypeId",
                principalTable: "unitTypes",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_unitTypes_UnitTypeId",
                table: "ProductPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_unitTypes_UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_unitTypes",
                table: "unitTypes");

            migrationBuilder.RenameTable(
                name: "unitTypes",
                newName: "UnitType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitType",
                table: "UnitType",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_UnitType_UnitTypeId",
                table: "ProductPrices",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_UnitType_UnitTypeId",
                table: "ProductStocks",
                column: "UnitTypeId",
                principalTable: "UnitType",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
