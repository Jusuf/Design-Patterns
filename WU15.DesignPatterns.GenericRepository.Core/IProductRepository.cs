using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public interface IProductRepository : IRepository<Product, int>
    {
        IEnumerable<Product> FindByDescription(string description);
    }
}
