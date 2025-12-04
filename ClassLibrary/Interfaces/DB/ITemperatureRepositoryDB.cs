using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    public interface ITemperatureRepositoryDB
    {
        Task<List<Temperature>> GetAllAsync();
        Task<Temperature?> GetByIdAsync(int id);
        Task<Temperature?> GetByRaspberryIdAsync(int id);
        Task<Temperature?> AddTemperatureAsync(Temperature temperature);
        Task<Temperature?> DeleteTemperatureAsync(int id);
        Task<int> DeleteOlderThan90DaysAsync();
    }
}
