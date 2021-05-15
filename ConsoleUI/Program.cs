using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
//SOLID : Open Closed Principle
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            //CategoryTest();

            ProductDetailsTest();

            //Console.ReadKey(true);
            Console.WriteLine("Hello World!");
        }

        private static void ProductDetailsTest()
        {
            ProductManager productManager = new(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductId + "/" + item.ProductName + "/" + item.CategoryName + "/" + item.UnitsInStock);
                }
            }
            else Console.WriteLine(result.Message);
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            foreach (var item in productManager.GetByUnitPrice(9.99m, 20).Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
