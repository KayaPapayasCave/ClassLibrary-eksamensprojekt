using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface INoiseRepository
    {
        List<Noise> GetAll();
        Noise? GetById(int id);
        Noise? GetByRaspberryId(int id);
        Noise? AddNoise(Noise noise);
        Noise? DeleteNoise(int id);
        Noise? UpdateNoise(Noise noise);
    }
}
