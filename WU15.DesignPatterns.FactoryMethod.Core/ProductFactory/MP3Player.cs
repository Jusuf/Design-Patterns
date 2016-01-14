using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.FactoryMethod.Core.ProductFactory
{
    class MP3Player : ElectronicProductBase
    {
        public string SupportedAudioFormats { get; set; }

        public string Frequency { get; set; }

        public MP3Player()
        {
            Name = "MP3 Player";
            Description = "An MP3 player is used for listening to music.";
        }
    }
}
