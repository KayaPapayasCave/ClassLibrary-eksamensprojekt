using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    /// <summary>
    /// Interface class for Humidity Repository classes
    /// </summary>
    public interface IHumidityRepositoryDB
    {
        /// <summary>
        /// Function to get all Humidity class items, asynchronous
        /// </summary>
        /// <returns>List of Humidity class items</returns>
        Task<List<Humidity>> GetAllAsync();

        /// <summary>
        /// Function to get singular Humidity class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Humidity class item, possibility for null</returns>
        Task<Humidity?> GetByIdAsync(int id);

        /// <summary>
        /// Funcction to get multiple Humidity class items, by Raspberry-Id, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Humidity class items</returns>
        Task<List<Humidity>> GetByRaspberryIdAsync(int id);

        /// <summary>
        /// Function to add singular Humidity class item, asynchronous
        /// </summary>
        /// <param name="humidity">Humidity class item</param>
        /// <returns>Humidity class item, possibility for null</returns>
        Task<Humidity?> AddHumidityAsync(Humidity humidity);

        /// <summary>
        /// Function to delete singular Humidity class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Humidity class item, possibility for null</returns>
        Task<Humidity?> DeleteHumidityAsync(int id);

        /// <summary>
        /// Function to delete multiple Humidity class items, asynchronous
        /// </summary>
        /// <returns>integer, number of affected rows</returns>
        Task<int> DeleteOlderThan90DaysAsync();
    }
}
