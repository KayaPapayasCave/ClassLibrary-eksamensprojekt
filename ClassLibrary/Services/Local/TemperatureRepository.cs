using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Local
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private List<Temperature> _temperatures;
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
                    Time = now
                },
                new Temperature
                {
                    Id = 1,
                    RaspberryId = 1,
                    Celsius = 27,
                    Time = now.AddMinutes(-10)
                },
                new Temperature
                {
                    Id = 2,
                    RaspberryId = 1,
                    Celsius = 28,
                    Time = now.AddMinutes(-20)
                },
                new Temperature
                {
                    Id = 3,
                    RaspberryId = 1,
                    Celsius = 29,
                    Time = now.AddMinutes(-30)
                },
            };
        }

        public List<Temperature> GetAll()
        {
            return _temperatures;
        }

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

        public Temperature? GetByRaspberryId(int id)
        {
            foreach (var temperature in _temperatures)
            {
                if (temperature.RaspberryId == id)
                {
                    return temperature;
                }
            }
            return null;
        }

        public Temperature? AddTemperature(Temperature temperature)
        {
            _temperatures.Add(temperature);
            return temperature;
        }

        public Temperature? DeleteTemperature(int id)
        {
            Temperature? temperature = GetById(id);
            if (temperature == null) return null;
            _temperatures.Remove(temperature);
            return temperature;
        }

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
