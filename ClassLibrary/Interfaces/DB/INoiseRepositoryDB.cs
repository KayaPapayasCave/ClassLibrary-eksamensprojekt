using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    /// <summary>
    /// Interface class for Noise Database Repository classes
    /// </summary>
    public interface INoiseRepositoryDB
    {
        /// <summary>
        /// Function to return all Noise class items, asynchronous
        /// </summary>
        /// <returns>List of Noise class items</returns>
        Task<List<Noise>> GetAllAsync();

        /// <summary>
        /// Function to return singular Noise class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Noise class item, possibility for null</returns>
        Task<Noise?> GetByIdAsync(int id);

        /// <summary>
        /// Function to get multiple Noise class items, by Raspberry-Id, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Noise class items</returns>
        Task<List<Noise>> GetByRaspberryIdAsync(int id);

        /// <summary>
        /// Function to add singular Noise class item, asynchronous
        /// </summary>
        /// <param name="noise">Noise class item</param>
        /// <returns>Noise class item, possibility for null</returns>
        Task<Noise?> AddNoiseAsync(Noise noise);

        /// <summary>
        /// Function to delete singular Noise class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Noise class item, possibility for null</returns>
        Task<Noise?> DeleteNoiseAsync(int id);

        /// <summary>
        /// Function to delete multiple Noise class items, asynchronous
        /// </summary>
        /// <returns>integer, number of affected rows</returns>
        Task<int> DeleteOlderThan90DaysAsync();
    }
}
