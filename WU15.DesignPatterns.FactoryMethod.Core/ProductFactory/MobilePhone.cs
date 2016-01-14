using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.FactoryMethod.Core.ProductFactory
{
    class MobilePhone : ElectronicProductBase
    {
        public PhoneType Phonetype { get; set; }

        public MobilePhone()
        {
            Name = "Mobile Phone";
            Description = "Enables mobile phone calls.";
        }
    }
}
