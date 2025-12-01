using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.DB
{
    public class LightRepositoryDB : ILightRepositoryDB
    {
        public Task<List<Light>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Light?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Light?> GetByRaspberryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Light?> AddLightAsync(Light light)
        {
            throw new NotImplementedException();
        }

        public Task<Light?> DeleteLightAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
