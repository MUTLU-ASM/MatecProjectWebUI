using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductPriceManager : IProductPriceService
    {
        //Dependency Injection
        IProductPriceDal _productPriceDal;

        public ProductPriceManager(IProductPriceDal productPriceDal)
        {
            _productPriceDal = productPriceDal;
        }
        public void TAdd(ProductPrice entity)
        {
            _productPriceDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _productPriceDal.Delete(id);
        }

        public List<ProductPrice> TGetAllList()
        {
            return _productPriceDal.GetAllList();
        }

        public ProductPrice TGetById(int id)
        {
            return _productPriceDal.GetById(id);
        }

        public List<ProductPrice> TGetListInclude()
        {
            return _productPriceDal.GetListInclude();
        }

        public void TUpdate(ProductPrice entity)
        {
            _productPriceDal.Update(entity);
        }
    }
}
