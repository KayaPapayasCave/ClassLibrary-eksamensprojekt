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
    /// A repository class for managing Temperature data.
    /// </summary>
    public class TemperatureRepository : ITemperatureRepository
    {
        /// <summary>
        /// A private list to store Temperature objects.
        /// </summary>
        private List<Temperature> _temperatures;

        /// <summary>
        /// An empty constructor that initializes the TemperatureRepository with some sample data.
        /// </summary>
        public TemperatureRepository()
        {
            DateTime now = DateTime.Now;

            _temperatures = new List<Temperature>
            {
                new Temperature
                {
                    Id = 0,
                    RaspberryId = 1,
                    Celsius = 26,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
                new Temperature
                {
                    Id = 1,
                    RaspberryId = 1,
                    Celsius = 27,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
                new Temperature
                {
                    Id = 2,
                    RaspberryId = 1,
                    Celsius = 28,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
                new Temperature
                {
                    Id = 3,
                    RaspberryId = 1,
                    Celsius = 29,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
            };
        }

        /// <summary>
        /// A method to get all Temperature objects.
        /// </summary>
        public List<Temperature> GetAll()
        {
            return _temperatures;
        }

        /// <summary>
        /// A method to get a Temperature object by its Id.
        /// </summary>
        public Temperature? GetById(int id)
        {
            foreach (var temperature in _temperatures)
            {
                if (temperature.Id == id)
                {
                    return temperature;
                }
            }
            return null;
        }

        /// <summary>
        /// A method to get Temperature objects by RaspberryId, and returns a list.
        /// </summary>
        public List<Temperature> GetByRaspberryId(int id)
        {
            List<Temperature> tempList = new List<Temperature>();
            foreach (var temperature in _temperatures)
            {
                if (temperature.RaspberryId == id)
                {
                    tempList.Add(temperature);
                }
            }
            return tempList;
        }

        /// <summary>
        /// A method to add a new Temperature object.
        /// </summary>
        public Temperature? AddTemperature(Temperature temperature)
        {
            _temperatures.Add(temperature);
            return temperature;
        }

        /// <summary>
        /// A method to delete a Temperature object by its Id.
        /// </summary>
        public Temperature? DeleteTemperature(int id)
        {
            Temperature? temperature = GetById(id);
            if (temperature == null) return null;
            _temperatures.Remove(temperature);
            return temperature;
        }

        /// <summary>
        /// A method to update an existing Temperature object.
        /// </summary>
        public Temperature? UpdateTemperature(Temperature temperature)
        {
            Temperature? oldTemperature = GetById(temperature.Id);
            if (oldTemperature == null) return null;
            oldTemperature.RaspberryId = temperature.RaspberryId;
            oldTemperature.Celsius = temperature.Celsius;
            oldTemperature.Time = temperature.Time;
            return temperature;
        }
    }
}
