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
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetByUnitPrice(9.99m,20))
            {
                Console.WriteLine(item.ProductName);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
