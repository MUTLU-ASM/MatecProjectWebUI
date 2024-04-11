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
    public class UnitTypeManager : IUnitTypeService
    {
        //Dependency Injection
        IUnitTypeDal _unitTypeDal;

        public UnitTypeManager(IUnitTypeDal unitTypeDal)
        {
            _unitTypeDal = unitTypeDal;
        }

        public void TAdd(UnitType entity)
        {
            _unitTypeDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _unitTypeDal.Delete(id);
        }

        public List<UnitType> TGetAllList()
        {
            return _unitTypeDal.GetAllList();
        }

        public UnitType TGetById(int id)
        {
            return _unitTypeDal.GetById(id);
        }

        public void TUpdate(UnitType entity)
        {
            _unitTypeDal.Update(entity);
        }
    }
}
