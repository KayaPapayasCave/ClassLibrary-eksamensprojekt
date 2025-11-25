using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Humidity
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double HumidityPercent { get; set; } // double to catch f.x. 35.81%, 1.9%... etc
        public DateTime Time { get; set; }

    }
}
