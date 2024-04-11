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
    public class EfProductPriceDal : GenericRepository<ProductPrice>, IProductPriceDal
    {
        Context db = new Context();
        public List<ProductPrice> GetListInclude()
        {
            return db.ProductPrices.Include(x=> x.Price).Include(x =>x.UnitType).ToList();
        }
    }
}
