using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Noise
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double Decibel { get; set; }
        public DateTime Time { get; set; }
    }
}
