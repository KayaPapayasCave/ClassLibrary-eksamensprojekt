using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    public interface ILightRepositoryDB
    {
        Task<List<Light>> GetAllAsync();
        Task<Light?> GetByIdAsync(int id);
        Task<List<Light>> GetByRaspberryIdAsync(int id);
        Task<Light?> AddLightAsync(Light light);
        Task<Light?> DeleteLightAsync(int id);
        Task<int> DeleteOlderThan90DaysAsync();
    }
}
