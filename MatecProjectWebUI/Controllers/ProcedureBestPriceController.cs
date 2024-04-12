using DataAccessLayer.Concrete;
using MatecProjectWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MatecProjectWebUI.Controllers
{
    public class ProcedureBestPriceController : Controller
    {
        Context db = new Context();

        public async Task<IActionResult> Index()
        {
            //SqlParameter nesneleri oluşturulur ve her biri bir saklı yordam parametresini temsil eder,OUTPUT olması geriye deger donecegi anlamına gelir.
            SqlParameter productParameter = new SqlParameter("productCode", System.Data.SqlDbType.NVarChar, 1000) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter stockParameter = new SqlParameter("stock", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter priceParameter = new SqlParameter("price", System.Data.SqlDbType.Float) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter validityDateParameter = new SqlParameter("validityDate", System.Data.SqlDbType.DateTime) { Direction = System.Data.ParameterDirection.Output };
            SqlParameter companyParameter = new SqlParameter("company", System.Data.SqlDbType.NVarChar, 250) { Direction = System.Data.ParameterDirection.Output };

            await db.Database.ExecuteSqlRawAsync($"EXECUTE sp_GetPrice '98A457AST',@productCode OUTPUT,@stock OUTPUT,@price OUTPUT,@validityDate OUTPUT,@company OUTPUT", productParameter, stockParameter, priceParameter, validityDateParameter, companyParameter);

            //Olusturulan model üzerinde gosterilmek istenilen bilgileri procedure fonksiyondan donen verileri model bilgilerine aktararak verilere erisilmis olundu. 
            List<ProcedureBestPriceModel> values = new List<ProcedureBestPriceModel>();

            ProcedureBestPriceModel model = new ProcedureBestPriceModel
            {
                ProductCode = productParameter.Value.ToString(),
                Stock = Convert.ToInt32(stockParameter.Value),
                Price = Convert.ToDouble(priceParameter.Value),
                ValidityDate = Convert.ToDateTime(validityDateParameter.Value),
                Company = companyParameter.Value.ToString()
            };

            values.Add(model);

            return View(values);
        }
    }
}
