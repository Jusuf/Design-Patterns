using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public class Product
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
