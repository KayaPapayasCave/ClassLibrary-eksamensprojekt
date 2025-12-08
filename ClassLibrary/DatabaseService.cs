using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;

namespace ClassLibrary
{
    /// <summary>
    /// Test class for Database Repository Intefaces
    /// </summary>
    public class DatabaseService
    {
        private readonly ITemperatureRepositoryDB _temperatureRepo;
        private readonly IHumidityRepositoryDB _humidityRepo;
        private readonly INoiseRepositoryDB _noiseRepo;
        private readonly ILightRepositoryDB _lightRepo;

        /// <summary>
        /// Constructor, creates object, containing empty Database Repository Interfaces
        /// </summary>
        /// <param name="temperatureRepo">Temperature Database Repository Interface class item</param>
        /// <param name="humidityRepo">Humidity Database Repository Interface class item</param>
        /// <param name="noiseRepo">Noise Database Repository Interface class item</param>
        /// <param name="lightRepo">Light Database Repository Interface class item</param>
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

        /// <summary>
        /// Function to test connectivity to database, asynchronous
        /// </summary>
        /// <returns>boolean, true = connected, false = not connected</returns>
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

        /// <summary>
        /// Function to get all Temperature class items in database
        /// </summary>
        /// <returns>List of Temperature class items</returns>
        // ✅ Expose repository data as lists
        public async Task<List<Temperature>> GetAllTemperaturesAsync()
        {
            return await _temperatureRepo.GetAllAsync();
        }

        /// <summary>
        /// Function to get all Humidity class items in database
        /// </summary>
        /// <returns>List of Humidity class items</returns>
        public async Task<List<Humidity>> GetAllHumidityAsync()
        {
            return await _humidityRepo.GetAllAsync();
        }

        /// <summary>
        /// Function to get all Noise class items in database
        /// </summary>
        /// <returns>List of Noise class items</returns>
        public async Task<List<Noise>> GetAllNoiseAsync()
        {
            return await _noiseRepo.GetAllAsync();
        }

        /// <summary>
        /// Function to get all Light class items in database
        /// </summary>
        /// <returns>List of Light class items</returns>
        public async Task<List<Light>> GetAllLightAsync()
        {
            return await _lightRepo.GetAllAsync();
        }
    }
}
