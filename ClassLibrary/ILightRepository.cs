using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ILightRepository
    {
        List<Light> GetAll();
        Light? GetById(int id);
        Light? GetByRaspberryId(int id);
        Light? AddLight(Light light);
        Light? DeleteLight(int id);
        Light? UpdateLight(Light light);
    }
}
