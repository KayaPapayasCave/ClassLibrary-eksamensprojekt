using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Temperature
    {
        public int Id { get; set; }
        public int RaspberryId { get; set; }
        public double Celsius { get; set; }
        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }

        public Temperature(int id, int rId, double celsius, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = rId;
            Celsius = celsius;
            Date = date;
            Time = time;
        }

        public Temperature()
        {
            
        }

        public double Fahrenheit()
        {
            return Celsius*1.8+32;
        }
    }
}
