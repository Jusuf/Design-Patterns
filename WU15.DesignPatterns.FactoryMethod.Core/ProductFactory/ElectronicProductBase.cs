using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.FactoryMethod.Core.ProductFactory
{
    public abstract class ElectronicProductBase
    {
        public string Name { get; set; }

        public string Memory { get; set; }

        public string Description { get; set; }
    }
}
