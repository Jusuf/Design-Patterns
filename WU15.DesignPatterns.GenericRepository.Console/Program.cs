using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WU15.DesignPatterns.GenericRepository.Core;

namespace WU15.DesignPatterns.GenericRepository.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataContext = new ApplicationContext("CustomerDataContext");

            // 1) Customers
            var customerRepository = new Repository<Customer, int>(dataContext);

            customerRepository.Insert(new Customer() { Firstname = "Ulla", Lastname = "Bulla" });
            customerRepository.Insert(new Customer() { Firstname = "Tora", Lastname = "Dora" });
            customerRepository.Save();

            var allCustomers = customerRepository.GetAll().ToList();
            foreach (var customer in allCustomers)
            {
                System.Console.WriteLine("Id: {0} Name: {1}", customer.Id, customer.Firstname);
            }

            var last = allCustomers.Last();
            customerRepository.Delete(last.Id);
            customerRepository.Save();

            allCustomers = customerRepository.GetAll().ToList();
            foreach (var customer in allCustomers)
            {
                System.Console.WriteLine("Id: {0} Name: {1}", customer.Id, customer.Firstname);
            }

            System.Console.WriteLine("**************************************");

            // 2) Orders
            var orderCustomer = allCustomers.Last();
            var orderRepository = new Repository<Order, int>(dataContext);

            orderRepository.Insert(new Order() { Date = DateTime.Now, Customer = orderCustomer });
            orderRepository.Save();

            var allOrders = orderRepository.GetAll().ToList();
            foreach (var order in allOrders)
            {
                System.Console.WriteLine(
                    "Id: {0} Order Date: {1} Customer: {2}",
                    order.Id,
                    order.Date.ToShortDateString(),
                    order.Customer.Firstname);
            }

            // 3) Extended Products
            var productRepository = new ProductRepository(dataContext);

            productRepository.Insert(new Product() { Description = "A green bike", Name = "Scott", SKU = "1234567-890" });
            productRepository.Save();

            var foundProducts = productRepository.FindByDescription("green");
            foreach (var product in foundProducts)
            {
                System.Console.WriteLine("Id: {0} Name: {1} Description: {2}",
                    product.Id,
                    product.Name,
                    product.Description);
            }

            System.Console.ReadLine();
        }
    }
}
