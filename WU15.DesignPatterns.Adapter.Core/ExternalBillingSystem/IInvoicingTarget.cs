using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.ExternalBillingSystem
{
    public interface IInvoicingTarget
    {
        List<string> GetCustomerList();
    }
}
