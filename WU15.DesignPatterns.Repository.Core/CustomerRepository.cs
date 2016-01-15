using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WU15.DesignPatterns.Repository.Core
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository()
        {
            context = new CustomerContext();
        }

        public CustomerRepository(string connectionStringName)
        {
            context = new CustomerContext(connectionStringName);
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(int Id)
        {
            return context.Customers.Find(Id);
        }

        public void Insert(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void Delete(int Id)
        {
            var customer = context.Customers.Find(Id);
            context.Customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
               
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

       
    }
}
