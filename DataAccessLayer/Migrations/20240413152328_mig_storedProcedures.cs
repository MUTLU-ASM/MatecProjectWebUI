using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_storedProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE PROCEDURE sp_GetPrice
	                                (
	                                @Code NVARCHAR(MAX),
	                                @ProductCode NVARCHAR(MAX) OUTPUT,
	                                @Stock INT OUTPUT,
	                                @Price FLOAT OUTPUT,
	                                @ValidityDate DATETIME2(7) OUTPUT,
	                                @Company NVARCHAR(250) OUTPUT
	                                )
                                AS
                                DECLARE @CurrentDate DATETIME2(7);
								SET @CurrentDate = GETDATE();
                                SELECT TOP 1 @ProductCode=x.Code,@Stock=y.Stock,@Price=z.Price,@ValidityDate=z.ValidityDate,@Company=c.Name FROM Products x
                                JOIN ProductStocks y ON x.ProductId = y.ProductId
                                JOIN ProductPrices z ON x.ProductId = z.ProductId
                                JOIN Companies c ON x.CompanyId = c.CompanyId
                                WHERE x.Code=@Code AND z.ValidityDate > @CurrentDate
                                ORDER BY
                                        z.Price
                                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_GetPrice");
        }
    }
}
