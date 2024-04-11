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
    public class ProductStockManager : IProductStockService
    {
        //Dependency Injection
        IProductStockDal _productStockDal;

        public ProductStockManager(IProductStockDal productStockDal)
        {
            _productStockDal = productStockDal;
        }

        public void TAdd(ProductStock entity)
        {
            _productStockDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _productStockDal.Delete(id);
        }

        public List<ProductStock> TGetAllList()
        {
            return _productStockDal.GetAllList();
        }

        public ProductStock TGetById(int id)
        {
            return _productStockDal.GetById(id);
        }

        public List<ProductStock> TGetListInclude()
        {
            return _productStockDal.GetListInclude();
        }

        public void TUpdate(ProductStock entity)
        {
            _productStockDal.Update(entity);
        }
    }
}
