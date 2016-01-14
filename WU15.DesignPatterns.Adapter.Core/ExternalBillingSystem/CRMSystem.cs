using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.ExternalBillingSystem
{
    public class CRMSystem
    {
        public string[][] GetCustomers()
        {
            string[][] customers = new string[4][];

            customers[0] = new string[] { "10", "SAS" };
            customers[1] = new string[] { "11", "Adlibris" };
            customers[2] = new string[] { "12", "Coop" };
            customers[3] = new string[] { "13", "ICA" };

            return customers;
        }
    }
}
