using ERestaurant.Business.Abstract;
using ERestaurant.Business.Concrete;
using ERestaurant.DataAccess.Abstract;
using ERestaurant.DataAccess.Concrete.EntityFrameWork;
using Ninject.Modules;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDal>().To<EfCategoryDal>();
        }
    }
}
