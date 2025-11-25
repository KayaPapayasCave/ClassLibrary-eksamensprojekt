using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Temperature
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double Celsius { get; set; }
        public DateTime Time { get; set; }

        public double Fahrenheit()
        {
            return (Celsius*1.8)+32;
        }
    }
}
