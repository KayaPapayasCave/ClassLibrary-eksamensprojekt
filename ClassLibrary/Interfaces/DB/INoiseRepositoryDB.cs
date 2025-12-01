using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    public interface INoiseRepositoryDB
    {
        Task<List<Noise>> GetAllAsync();
        Task<Noise?> GetByIdAsync(int id);
        Task<Noise?> GetByRaspberryIdAsync(int id);
        Task<Noise?> AddNoiseAsync(Noise noise);
        Task<Noise?> DeleteNoiseAsync(int id);
    }
}
