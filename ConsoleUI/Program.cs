using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();

            Console.ReadLine();
        }

        private static void ProductTest()
        {
            
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetAll();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
                Console.WriteLine(result.Message);
            }
            else 
            {
                Console.WriteLine(result.Message);
            }
            
        }

    }
}
