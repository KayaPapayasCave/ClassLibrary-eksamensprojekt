using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.Local
{
    public interface IHumidityRepository
    {
        List<Humidity> GetAll();
        Humidity? GetById(int id);
        List<Humidity> GetByRaspberryId(int id);
        Humidity? AddHumidity(Humidity humidity);
        Humidity? DeleteHumidity(int id);
        Humidity? UpdateHumidity(Humidity humidity);
    }
}
