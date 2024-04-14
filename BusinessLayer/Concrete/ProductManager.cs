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
    public class ProductManager : IProductService
    {
        //Dependency Injection : yazılım geliştirme sürecinde, bir bileşenin başka bir bileşene bağımlılıklarını doğrudan kendisi yönetmek yerine, bu bağımlılıkların dışarıdan enjekte edilmesi prensibine dayanır. Bu, kodun daha modüler, test edilebilir ve bakımı daha kolay hale gelmesini sağlar.

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> TGetAllList()
        {
            return _productDal.GetAllList();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListInclude()
        {
            return _productDal.GetListInclude();
        }

        public List<Product> TGetListIncludeAndWhere()
        {
            return _productDal.GetListIncludeAndWhere();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
