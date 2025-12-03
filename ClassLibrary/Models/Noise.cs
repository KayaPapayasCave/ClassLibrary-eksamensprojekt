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
        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }

        public Noise(int id, int rId, double decibel, TimeOnly time, DateOnly date)
        {
            Id = id;
            RaspberryId = rId;
            Decibel = decibel;
            Date = date;
            Time = time;

        }

        public Noise()
        {
            
        }
    }
}
