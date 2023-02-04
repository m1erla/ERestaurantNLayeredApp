using ERestaurant.DataAccess.Abstract;
using ERestaurant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product> 
            {
              new Product
              {
                 ProductId = 79,
                 CategoryId= 7,
                 ProductName = "DinnerTable",
                 QuantityPerUnit = "35 kg pkg",
                 UnitPrice = 5560,
                 UnitsInStock= 225
              }
            };   
              return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
