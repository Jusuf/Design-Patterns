using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Facade.Core.MortgageEligibility
{
    // Subsystem
    public class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine("# Checking the credit for {0} {1}.", 
                customer.FirstName, 
                customer.LastName);

            return true;
        }
    }
}
