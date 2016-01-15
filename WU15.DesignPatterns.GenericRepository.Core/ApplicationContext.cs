using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(string connectionString) : base(connectionString) { }

        // 1) 
        public virtual DbSet<Customer> Customers { get; set; }

        // 2)
        public virtual DbSet<Order> Orders { get; set; }

        // 3)
        public virtual DbSet<Product> Products { get; set; }
    }
}
