using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WU15.DesignPatterns.FactoryMethod.Core.ProductFactory;

namespace WU15.DesignPatterns.FactoryMethod.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductFactory
            ProductFactory productFactory = new ProductFactory();
            foreach (ProductType productType in Enum.GetValues(typeof(ProductType)))
            {
                var product = productFactory.CreateProduct(productType);

                System.Console.WriteLine(
                    "Name: {0} ,Description: {1}",
                    product.Name,
                    product.Description);
            }

            System.Console.ReadLine();
        }
    }
}
