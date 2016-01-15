using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WU15.DesignPatterns.Repository.Core;

namespace WU15.DesignPatterns.Repository.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository("CustomerDataContext");

            repository.Insert(new Customer() { FirstName = "Kalle", Lastname = "Kula" });
            repository.Insert(new Customer() { FirstName = "Lena", Lastname = "Bena" });
            repository.Save();

            var allCustomers = repository.GetAll();
            foreach (var customer in allCustomers)
            {
                System.Console.WriteLine(customer.FirstName);
            }

            System.Console.ReadLine();

        }
    }
}
