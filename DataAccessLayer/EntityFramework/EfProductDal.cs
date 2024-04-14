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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        Context db = new Context();
        public List<Product> GetListInclude()
        {
             return db.Products.Include(x => x.Company).Include(x=>x.ProductPrice).Include(x=>x.ProductStock).Include(x=>x.ProductStock.UnitType).ToList();
        }
        //Burada sart olarak gecerlilik tarihi simdiki tarih den kücük olması ve status degeri true olan degerleri dondurmek.
        public List<Product> GetListIncludeAndWhere()
        {
            return db.Products.Include(x => x.Company).Include(x => x.ProductPrice).Include(x => x.ProductStock).Include(x => x.ProductStock.UnitType).Where(x => x.ProductPrice.ValidityDate > DateTime.Now && x.Status == 1).ToList();
        }
    }
}
