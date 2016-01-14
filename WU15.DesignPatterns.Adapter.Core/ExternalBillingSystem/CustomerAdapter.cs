using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.ExternalBillingSystem
{
    public class CustomerAdapter : CRMSystem, IInvoicingTarget
    {
        public List<string> GetCustomerList()
        {
            List<string> employeeList = new List<string>();
            string[][] employees = GetCustomers();

            foreach (string[] employee in employees)
            {
                employeeList.Add(employee[0]);
                employeeList.Add(" - ");
                employeeList.Add(employee[1]);
                employeeList.Add("\n");
            }

            return employeeList;
        }
    }
}
