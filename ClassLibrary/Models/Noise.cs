using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    /// <summary>
    /// A noise model class representing noise data.
    /// </summary>
    public class Noise
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
        /// gets the noise level in decibels.
        /// </summary>
        public double Decibel { get; set; }

        /// <summary>
        /// Gets or sets the time value represented as a TimeOnly structure.
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Gets or sets the date associated with the current instance.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// A parameterized constructor to initialize a noise object with specified values.
        /// </summary>
        public Noise(int id, int rId, double decibel, DateOnly date, TimeOnly time)
        {
            Id = id;
            RaspberryId = rId;
            Decibel = decibel;
            Date = date;
            Time = time;

        }

        /// <summary>
        /// An empty constructor for Noise class.
        /// </summary>
        public Noise()
        {
            
        }
    }
}
