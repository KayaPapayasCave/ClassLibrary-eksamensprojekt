using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IHumidityRepository
    {
        List<Humidity> GetAll();
        Humidity? GetById(int id);
        Humidity? GetByRaspberryId(int id);
        Humidity? AddHumidity(Humidity humidity);
        Humidity? DeleteHumidity(int id);
        Humidity? UpdateHumidity(Humidity humidity);
    }
}
