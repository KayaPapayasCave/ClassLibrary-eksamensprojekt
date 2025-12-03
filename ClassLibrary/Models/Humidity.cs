using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Humidity
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double HumidityPercent { get; set; } // double to catch f.x. 35.81%, 1.9%... etc
        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }

        public Humidity(int id, int raspberryId, double humidityPercent, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = raspberryId;
            HumidityPercent = humidityPercent;
            Date = date;
            Time = time;
        }

        public Humidity()
        {
            
        }
    }
}
