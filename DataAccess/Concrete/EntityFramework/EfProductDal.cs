using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void add(Product entity)
        {
            //IDıspossable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext()) //northwind context işi bitince bellekten atılacak
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //northwind context işi bitince bellekten atılacak
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext()) //northwind context işi bitince bellekten atılacak
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext()) //northwind context işi bitince bellekten atılacak
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }
            public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //northwind context işi bitince bellekten atılacak
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
