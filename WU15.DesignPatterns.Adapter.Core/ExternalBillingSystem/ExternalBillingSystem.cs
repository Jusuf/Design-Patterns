using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.ExternalBillingSystem
{
    public class ExternalBillingSystem
    {
        private IInvoicingTarget customerSource;

        public ExternalBillingSystem(IInvoicingTarget customerSource)
        {
            this.customerSource = customerSource;
        }

        public void RunInvoicing()
        {
            List<string> customerList = customerSource.GetCustomerList();

            Console.WriteLine("_______ Customer List _______");
            foreach (var item in customerList)
            {
                Console.Write(item);
            }
        }
    }
}
