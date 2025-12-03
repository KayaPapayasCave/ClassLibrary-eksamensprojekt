using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Local
{
    public class HumidityRepository : IHumidityRepository
    {
        private List<Humidity> _humidities;
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
                        Time = TimeOnly.Parse($"{now.Hour}:{now.Minute}:{now.Second}"),
                        Date = DateOnly.Parse($"{now.Date}")
                    },
                    new Humidity
                    {
                        Id = 1,
                        RaspberryId = 1,
                        HumidityPercent = 27,
                        Time = TimeOnly.Parse($"{now.Hour}:{now.Minute-10}:{now.Second}"),
                        Date = DateOnly.Parse($"{now.Date}")
                    },
                    new Humidity
                    {
                        Id = 2,
                        RaspberryId = 1,
                        HumidityPercent = 28,
                        Time = TimeOnly.Parse($"{now.Hour}:{now.Minute-20}:{now.Second}"),
                        Date = DateOnly.Parse($"{now.Date}")
                    },
                    new Humidity
                    {
                        Id = 3,
                        RaspberryId = 1,
                        HumidityPercent = 29,
                        Time = TimeOnly.Parse($"{now.Hour}:{now.Minute-30}:{now.Second}"),
                        Date = DateOnly.Parse($"{now.Date}")
                    },
                };
        }

        public List<Humidity> GetAll()
        {
            return _humidities;
        }

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

        public Humidity? GetByRaspberryId(int id)
        {
            foreach (var humidity in _humidities)
            {
                if (humidity.RaspberryId == id)
                {
                    return humidity;
                }
            }
            return null;
        }

        public Humidity? AddHumidity(Humidity humidity)
        {
            _humidities.Add(humidity);
            return humidity;
        }

        public Humidity? DeleteHumidity(int id)
        {
            Humidity? humidity = GetById(id);
            if (humidity == null) return null;
            _humidities.Remove(humidity);
            return humidity;
        }

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
