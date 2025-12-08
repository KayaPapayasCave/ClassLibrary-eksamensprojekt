using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    /// <summary>
    /// A temperature model class representing temperature data.
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// gets or sets the unique identifier for a Raspberry device.
        /// </summary>
        public int RaspberryId { get; set; }

        /// <summary>
        /// gets the temperature in Celsius.
        /// </summary>
        public double Celsius { get; set; }

        /// <summary>
        /// gets or sets the time value represented as a TimeOnly structure.
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// gets or sets the date associated with the current instance.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// A parameterized constructor to initialize a temperature object with specified values.
        /// </summary>
        public Temperature(int id, int rId, double celsius, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = rId;
            Celsius = celsius;
            Date = date;
            Time = time;
        }

        /// <summary>
        /// An empty constructor for Temperature class.
        /// </summary>
        public Temperature()
        {
            
        }

        /// <summary>
        /// A method to convert Celsius to Fahrenheit.
        /// </summary>
        /// <returns></returns>
        public double Fahrenheit()
        {
            return Celsius*1.8+32;
        }
    }
}
