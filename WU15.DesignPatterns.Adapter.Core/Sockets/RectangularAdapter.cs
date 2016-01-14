using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.Sockets
{
    public class RectangularAdapter 
    {
        private readonly CylindricalSocket socket;

        public RectangularAdapter()
        {
            socket = new CylindricalSocket();
        }

        public string GetPowerSupply(string rectangularPhase, string rectangularNeutral)
        {
            return socket.GetSupply(rectangularPhase, rectangularNeutral);
        }
    }
}
