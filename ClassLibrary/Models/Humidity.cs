using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    /// <summary>
    /// Represents a humidity measurement recorded by a specific Raspberry Pi device at a given date and time.
    /// </summary>
    public class Humidity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for a Raspberry device.
        /// </summary>
        public int RaspberryId { get; set; }

        /// <summary>
        /// Gets or sets the humidity level as a percentage.
        /// </summary>
        public double HumidityPercent { get; set; } // double to catch f.x. 35.81%, 1.9%... etc

        /// <summary>
        /// Gets or sets the time value represented as a TimeOnly structure.
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Gets or sets the date associated with the current instance.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// A parameterized constructor to initialize a Humidity object with specified values.
        /// </summary>
        public Humidity(int id, int raspberryId, double humidityPercent, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = raspberryId;
            HumidityPercent = humidityPercent;
            Date = date;
            Time = time;
        }

        /// <summary>
        /// a emty constructor for Humidity class.
        /// </summary>
        public Humidity()
        {
            
        }
    }
}
