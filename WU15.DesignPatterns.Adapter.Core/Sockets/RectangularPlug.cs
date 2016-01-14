using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Adapter.Core.Sockets
{
    public class RectangularPlug 
    {
        private readonly string rectangularPhase;
        private readonly string rectangularNeutral;

        public RectangularPlug(string rectangularPhase, string rectangularneutral)
        {
            this.rectangularPhase = rectangularPhase;
            this.rectangularNeutral = rectangularneutral;
        }

        public string GetPowerSupply()
        {
            var rectangularAdapter = new RectangularAdapter();

            return rectangularAdapter.GetPowerSupply(rectangularPhase, rectangularNeutral);
        }
    }
}
