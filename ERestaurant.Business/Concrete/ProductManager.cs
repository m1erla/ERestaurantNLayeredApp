using ERestaurant.Business.Abstract;
using ERestaurant.Business.Utilities;
using ERestaurant.Business.ValidationRules.FluentValidation;
using ERestaurant.DataAccess.Abstract;
using ERestaurant.Entities.Concrete;
using ERestaurant.DataAccess.Concrete;
using ERestaurant.DataAccess.Concrete.EntityFrameWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal) 
        { _productDal = productDal; }
        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId==categoryId);
        }

        public List<Product> GetProductByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
