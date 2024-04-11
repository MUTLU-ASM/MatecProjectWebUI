using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductStockDal : GenericRepository<ProductStock>, IProductStockDal
    {
        Context db = new Context();
        public List<ProductStock> GetListInclude()
        {
            return db.ProductStocks.Include(x=>x.UnitType).Include(x=>x.Product).ToList();
        }
    }
}
