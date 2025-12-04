using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class DatabaseService
    {
        private readonly ITemperatureRepositoryDB _temperatureRepo;
        private readonly IHumidityRepositoryDB _humidityRepo;
        private readonly INoiseRepositoryDB _noiseRepo;
        private readonly ILightRepositoryDB _lightRepo;

        public DatabaseService(
            ITemperatureRepositoryDB temperatureRepo,
            IHumidityRepositoryDB humidityRepo,
            INoiseRepositoryDB noiseRepo,
            ILightRepositoryDB lightRepo
        )
        {
            _temperatureRepo = temperatureRepo;
            _humidityRepo = humidityRepo;
            _noiseRepo = noiseRepo;
            _lightRepo = lightRepo;
        }

        // ✅ Test that the database is reachable using one repository
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                // Attempt to fetch a single record from Temperature as a lightweight test
                var temps = await _temperatureRepo.GetAllAsync();
                return temps != null;
            }
            catch
            {
                return false;
            }
        }

        // ✅ Expose repository data as lists
        public async Task<List<Temperature>> GetAllTemperaturesAsync()
        {
            return await _temperatureRepo.GetAllAsync();
        }

        public async Task<List<Humidity>> GetAllHumidityAsync()
        {
            return await _humidityRepo.GetAllAsync();
        }

        public async Task<List<Noise>> GetAllNoiseAsync()
        {
            return await _noiseRepo.GetAllAsync();
        }

        public async Task<List<Light>> GetAllLightAsync()
        {
            return await _lightRepo.GetAllAsync();
        }
    }
}
