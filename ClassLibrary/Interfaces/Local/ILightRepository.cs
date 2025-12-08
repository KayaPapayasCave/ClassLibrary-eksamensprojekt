using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.Local
{
    public interface ILightRepository
    {
        List<Light> GetAll();
        Light? GetById(int id);
        List<Light> GetByRaspberryId(int id);
        Light? AddLight(Light light);
        Light? DeleteLight(int id);
        Light? UpdateLight(Light light);
    }
}
