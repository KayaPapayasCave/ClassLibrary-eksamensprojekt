using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.DB
{
    public class HumidityRepositoryDB : IHumidityRepositoryDB
    {
        public Task<List<Humidity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Humidity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Humidity?> GetByRaspberryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Humidity?> AddHumidityAsync(Humidity humidity)
        {
            throw new NotImplementedException();
        }

        public Task<Humidity?> DeleteHumidityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
