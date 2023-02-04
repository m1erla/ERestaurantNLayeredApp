using ERestaurant.DataAccess.Abstract;
using ERestaurant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.DataAccess.Concrete.EntityFrameWork
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,ERestaurantContext>,ICategoryDal
    {
    }
}
