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
    public class CompanyManager : ICompanyService
    {
        //Dependency Injection
        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public void TAdd(Company entity)
        {
            _companyDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _companyDal.Delete(id);
        }

        public List<Company> TGetAllList()
        {
            return _companyDal.GetAllList();
        }

        public Company TGetById(int id)
        {
            return _companyDal.GetById(id);
        }

        public void TUpdate(Company entity)
        {
            _companyDal.Update(entity);
        }
    }
}
