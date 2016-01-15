using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.GenericRepository.Core
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
    }
}
