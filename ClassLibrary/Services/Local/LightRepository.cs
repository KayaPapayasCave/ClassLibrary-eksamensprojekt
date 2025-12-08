using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Local
{
    public class LightRepository : ILightRepository
    {
        private List<Light> _lights;
        public LightRepository()
        {
            DateTime now = DateTime.Now;

            _lights = new List<Light>
                {
                    new Light
                    {
                        Id = 0,
                        RaspberryId = 1,
                        Lumen = 26,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                    new Light
                    {
                        Id = 1,
                        RaspberryId = 1,
                        Lumen = 27,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                    new Light
                    {
                        Id = 2,
                        RaspberryId = 1,
                        Lumen = 28,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                    new Light
                    {
                        Id = 3,
                        RaspberryId = 1,
                        Lumen = 29,
                        Time = TimeOnly.FromDateTime(now),
                        Date = DateOnly.FromDateTime(now)
                    },
                };
        }

        public List<Light> GetAll()
        {
            return _lights;
        }

        public Light? GetById(int id)
        {
            foreach (var light in _lights)
            {
                if (light.Id == id)
                {
                    return light;
                }
            }
            return null;
        }

        public List<Light> GetByRaspberryId(int id)
        {
            List<Light> lighList = new List<Light>();
            foreach (var light in _lights)
            {
                if (light.RaspberryId == id)
                {
                    lighList.Add(light);
                }
            }
            return lighList;
        }

        public Light? AddLight(Light light)
        {
            _lights.Add(light);
            return light;
        }

        public Light? DeleteLight(int id)
        {
            Light? light = GetById(id);
            if (light == null) return null;
            _lights.Remove(light);
            return light;
        }

        public Light? UpdateLight(Light light)
        {
            Light? oldLight = GetById(light.Id);
            if (oldLight == null) return null;
            oldLight.RaspberryId = light.RaspberryId;
            oldLight.Lumen = light.Lumen;
            oldLight.Time = light.Time;
            return light;
        }
    }
}
