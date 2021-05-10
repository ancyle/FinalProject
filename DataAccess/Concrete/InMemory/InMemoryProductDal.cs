using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Bir veritabanından geliyormuş gibi simüle ediliyor
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
            new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Find by id using LINQ
            Product productToDelete = _products.SingleOrDefault(x=>x.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //ID ile çalışırken tek bir sonuç alacağımızdan ötürü First-Single farkı yoktur
            //Çoklu dönüşlerde FirstOrDefault gelen ilk sonucu çekerken Single tek sonuç olmadığı için Exception verir
            Product productToUpdate = _products.FirstOrDefault(x=>x.ProductId==product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
