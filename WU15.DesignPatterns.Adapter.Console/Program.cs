using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WU15.DesignPatterns.Adapter.Core.Sockets;
using WU15.DesignPatterns.Adapter.Core.ExternalBillingSystem;



namespace WU15.DesignPatterns.Adapter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sockets Adapter

            //var rectangularPlug = new RectangularPlug("Phase", "Neutral");

            //System.Console.WriteLine(rectangularPlug.GetPowerSupply());

            //****************************************************************

            // ExternalBillingSystem

            IInvoicingTarget invoicingTarget = new CustomerAdapter();
            ExternalBillingSystem client = new ExternalBillingSystem(invoicingTarget);
            client.RunInvoicing();

            //****************************************************************

            System.Console.ReadLine();
        }
    }
}
