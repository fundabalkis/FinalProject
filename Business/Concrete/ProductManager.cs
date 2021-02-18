using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //business'ın bildiği tek şey. Sadece entityFramework'e bağlı değiliz.

        public IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        List<Product> IProductService.GetAll()
        {
            //iş kodları 

            // yetkisi var mı ?
            return _productDal.GetAll();
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
