using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ITemperatureRepository
    {
        List<Temperature> GetAll();
        Temperature? GetById(int id);
        Temperature? GetByRaspberryId(int id);
        Temperature? AddTemperature(Temperature temperature);
        Temperature? DeleteTemperature(int id);
        Temperature? UpdateTemperature(Temperature temperature);
    }
}
