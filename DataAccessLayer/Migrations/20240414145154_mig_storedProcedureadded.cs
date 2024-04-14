using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_storedProcedureadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_unitTypes_UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.AlterColumn<int>(
                name: "UnitTypeId",
                table: "ProductStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_unitTypes_UnitTypeId",
                table: "ProductStocks",
                column: "UnitTypeId",
                principalTable: "unitTypes",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Cascade);
                
            migrationBuilder.Sql($@"CREATE PROCEDURE sp_GetPrice
                                    (
                                    @Number INT,
                                    @ProductCode NVARCHAR(MAX) OUTPUT,
                                    @Stock INT OUTPUT,
                                    @Price FLOAT OUTPUT,
                                    @ValidityDate DATETIME2(7) OUTPUT,
                                    @Company NVARCHAR(250) OUTPUT
                                    )
                                AS
                                DECLARE @CurrentDate DATETIME2(7);
                                SET @CurrentDate = GETDATE();
                                SELECT TOP (@Number) @ProductCode=x.Code,@Stock=y.Stock,@Price=z.Price,@ValidityDate=z.ValidityDate,@Company=c.Name FROM Products x
                                JOIN ProductStocks y ON x.ProductId = y.ProductId
                                JOIN ProductPrices z ON x.ProductId = z.ProductId
                                JOIN Companies c ON x.CompanyId = c.CompanyId
                                WHERE z.ValidityDate > @CurrentDate
                                ORDER BY
                                        z.Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStocks_unitTypes_UnitTypeId",
                table: "ProductStocks");

            migrationBuilder.AlterColumn<int>(
                name: "UnitTypeId",
                table: "ProductStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStocks_unitTypes_UnitTypeId",
                table: "ProductStocks",
                column: "UnitTypeId",
                principalTable: "unitTypes",
                principalColumn: "UnitTypeId");

            migrationBuilder.Sql($@"DROP PROC sp_GetPrice");
        }
    }
}
