﻿using ERestaurant.Business.Abstract;
using ERestaurant.DataAccess.Abstract;
using ERestaurant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal) 
        { _categoryDal = categoryDal; }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
    }
}
