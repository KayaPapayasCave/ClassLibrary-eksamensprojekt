using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Light
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double Lumen { get; set; }
        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }

        public Light(int id, int rId, double lumen, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = rId;
            Lumen = lumen;
            Date = date;
            Time = time;
        }

        public Light()
        {
            
        }
    }
}
