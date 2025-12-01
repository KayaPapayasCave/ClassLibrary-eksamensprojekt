using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.DB
{
    public class TemperatureRepositoryDB : ITemperatureRepositoryDB
    {
        public Task<List<Temperature>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Temperature?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Temperature?> GetByRaspberryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Temperature?> AddTemperatureAsync(Temperature temperature)
        {
            throw new NotImplementedException();
        }

        public Task<Temperature?> DeleteTemperatureAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
