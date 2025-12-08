using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    /// <summary>
    /// Interface class for Temperature Repository classes
    /// </summary>
    public interface ITemperatureRepositoryDB
    {
        /// <summary>
        /// Function to fetch all Temperature class items, asynchronous
        /// </summary>
        /// <returns>List of Temperature class items</returns>
        Task<List<Temperature>> GetAllAsync();

        /// <summary>
        /// Function to fetch singular Temperature class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Temperature class item, possibility for null</returns>
        Task<Temperature?> GetByIdAsync(int id);

        /// <summary>
        /// Function to fetch list of Temperature class items, by Raspberry-Id, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Temperature class items</returns>
        Task<List<Temperature>> GetByRaspberryIdAsync(int id);

        /// <summary>
        /// Function to add singular Temperature class item, asynchronous
        /// </summary>
        /// <param name="temperature">Temperature class item</param>
        /// <returns>Temperature class item, possibility for null</returns>
        Task<Temperature?> AddTemperatureAsync(Temperature temperature);

        /// <summary>
        /// Function to delete singular Temperature class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Temperature class item, possibility for null</returns>
        Task<Temperature?> DeleteTemperatureAsync(int id);

        /// <summary>
        /// Function to delete multiple Temperature class items, asynchronous
        /// </summary>
        /// <returns>integer, number of affected rows</returns>
        Task<int> DeleteOlderThan90DaysAsync();
    }
}
