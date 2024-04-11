﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TDelete(int id);
        void TUpdate(T entity);
        List<T> TGetAllList();
        T TGetById(int id);
    }
}