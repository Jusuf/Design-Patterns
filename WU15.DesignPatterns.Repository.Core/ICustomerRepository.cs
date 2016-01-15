using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Repository.Core
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(int id);

        void Insert(Customer customer);

        void Delete(int Id);

        void Update(Customer customer);

        void Save();
    }
}
