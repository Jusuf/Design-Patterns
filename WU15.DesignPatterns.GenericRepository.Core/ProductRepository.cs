using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }
    
        public IEnumerable<Product> FindByDescription(string description)
        {
            return GetAll()
                .Where(x => x.Description.ToLowerInvariant()
                .Contains(description.ToLowerInvariant()));
        }
}
}
