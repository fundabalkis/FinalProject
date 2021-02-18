using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;  //class içinde ama metot dışında global değişken, naming convention, referans tip 
        //(veri varmış gibi simüle edeceğiz ürün listesi oluşturduk)
        public InMemoryProductDal() //constructor bellekte referans aldığı zaman çalıştıracağı blok
        {
            //oracle,sql server,postgres,MongoDB
            _products = new List<Product>
            {
                new Product{ProductId =1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock =15},
                new Product{ProductId =2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock =3},
                new Product{ProductId =3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock =2},
                new Product{ProductId =4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock =65},
                new Product{ProductId =5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock =1}
            };
        }
        public void add(Product product)
        {
            _products.Add(product);
        }

        public void delete(Product product)
            
        {
           /* Product productToDelete =null; //listeyi dolaşır ve arar
            foreach (var p in _products)
            {
                if (product.ProductId==p.ProductId)
                {
                    productToDelete = p;
                }
                
            }
            */ 
              Product  productToDelete = _products.SingleOrDefault(p=>p.ProductId ==product.ProductId);//LINQ--tek bir eleman arayıp bulmaya yarar.
            //Products'ı dolaşır. Lambda p=> Sonunda iki sonuç döndürmemeli

              _products.Remove(productToDelete);
            //_products.Remove(product); //böyle yazarsak silmez. Çünkü, arayüzden aynı verileri girip göndermek önemli değil. 
            //Heap'de belli referanslar var. Arayüzden ID'si aynı bile olsa ürün new'leyip gönderince adres sil diyosun, referans veriyorsun silmez. 
            //Değer tip silinirdi.  Id'yi referans kullanıp sileceğiz.
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

       
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void update(Product product)
        {
            //gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock; //İşin mantığı bu, entity framework yapacak.

            List<Product> GetAllByCategory(int categoryId)
            {
                return _products.Where(p => p.CategoryId == categoryId).ToList();
            }
        }
    }
}
