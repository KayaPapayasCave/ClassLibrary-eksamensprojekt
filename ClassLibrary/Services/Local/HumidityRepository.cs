using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Local
{
    /// <summary>
    /// A repository class for managing Humidity data.
    /// </summary>
    public class HumidityRepository : IHumidityRepository
    {
        /// <summary>
        /// A private list to store Humidity objects.
        /// </summary>
        private List<Humidity> _humidities;

        /// <summary>
        /// An empty constructor that initializes the HumidityRepository with some sample data.
        /// </summary>
        public HumidityRepository()
        {
            DateTime now = DateTime.Now;

            _humidities = new List<Humidity>
                {
                    new Humidity
                    {
                        Id = 0,
                        RaspberryId = 1,
                        HumidityPercent = 26,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                    new Humidity
                    {
                        Id = 1,
                        RaspberryId = 1,
                        HumidityPercent = 27,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                    new Humidity
                    {
                        Id = 2,
                        RaspberryId = 1,
                        HumidityPercent = 28,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                    new Humidity
                    {
                        Id = 3,
                        RaspberryId = 1,
                        HumidityPercent = 29,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                };
        }

        /// <summary>
        /// Retrieves all Humidity records.
        /// </summary>
        public List<Humidity> GetAll()
        {
            return _humidities;
        }

        /// <summary>
        /// Retrieves a Humidity record by its unique identifier.
        /// </summary>
        public Humidity? GetById(int id)
        {
            foreach (var humidity in _humidities)
            {
                if (humidity.Id == id)
                {
                    return humidity;
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves Humidity records by RaspberryId, returns a list.
        /// </summary>
        public List<Humidity> GetByRaspberryId(int id)
        {
            List<Humidity> humiList = new List<Humidity>();
            foreach (var humidity in _humidities)
            {
                if (humidity.RaspberryId == id)
                {
                    humiList.Add(humidity);
                }
            }
            return humiList;
        }

        /// <summary>
        /// Adds a new Humidity record.
        /// </summary>
        public Humidity? AddHumidity(Humidity humidity)
        {
            _humidities.Add(humidity);
            return humidity;
        }

        /// <summary>
        /// Deletes a Humidity record by its unique identifier.
        /// </summary>
        public Humidity? DeleteHumidity(int id)
        {
            Humidity? humidity = GetById(id);
            if (humidity == null) return null;
            _humidities.Remove(humidity);
            return humidity;
        }

        /// <summary>
        /// Updates an existing Humidity record.
        /// </summary>
        public Humidity? UpdateHumidity(Humidity humidity)
        {
            Humidity? oldHumidity = GetById(humidity.Id);
            if (oldHumidity == null) return null;
            oldHumidity.RaspberryId = humidity.RaspberryId;
            oldHumidity.HumidityPercent = humidity.HumidityPercent;
            oldHumidity.Time = humidity.Time;
            return humidity;
        }
    }
}
