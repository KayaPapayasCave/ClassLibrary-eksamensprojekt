using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Light
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double Lumen { get; set; }
        public DateTime Time { get; set; }
    }
}
