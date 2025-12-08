using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    /// <summary>
    /// A light model class representing light data.
    /// </summary>
    public class Light
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
        /// gets the lumen value representing the intensity of light.
        /// </summary>
        public double Lumen { get; set; }

        /// <summary>
        /// Gets or sets the time value represented as a TimeOnly structure.
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Gets or sets the date associated with the current instance.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// A parameterized constructor to initialize a light object with specified values.
        /// </summary>
        public Light(int id, int rId, double lumen, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = rId;
            Lumen = lumen;
            Date = date;
            Time = time;
        }

        /// <summary>
        /// An empty constructor for Humidity class.
        /// </summary>
        public Light()
        {
            
        }
    }
}
