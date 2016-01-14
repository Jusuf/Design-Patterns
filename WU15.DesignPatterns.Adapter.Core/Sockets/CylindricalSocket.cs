using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.Sockets
{
    public class CylindricalSocket 
    {
        public string GetSupply(string cylindricalPhase, string cylindricalNeutral)
        {
            return "Connected! Power supply is ON.";
        }
    }
}
