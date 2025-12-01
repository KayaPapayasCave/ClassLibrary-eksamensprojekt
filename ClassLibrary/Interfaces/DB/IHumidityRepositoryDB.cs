using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    public interface IHumidityRepositoryDB
    {
        Task<List<Humidity>> GetAllAsync();
        Task<Humidity?> GetByIdAsync(int id);
        Task<Humidity?> GetByRaspberryIdAsync(int id);
        Task<Humidity?> AddHumidityAsync(Humidity humidity);
        Task<Humidity?> DeleteHumidityAsync(int id);
    }
}
