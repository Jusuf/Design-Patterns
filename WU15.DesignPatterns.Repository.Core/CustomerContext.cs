using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace WU15.DesignPatterns.Repository.Core
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }

        public CustomerContext(string connectionStringName) : base(connectionStringName) { }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
