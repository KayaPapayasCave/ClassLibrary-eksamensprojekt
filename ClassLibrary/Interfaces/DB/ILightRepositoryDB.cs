using ClassLibrary.Models;

namespace ClassLibrary.Interfaces.DB
{
    /// <summary>
    /// Interface class for Light Database Repository classes
    /// </summary>
    public interface ILightRepositoryDB
    {
        /// <summary>
        /// Function to get all Light class items, asynchronous
        /// </summary>
        /// <returns>List of Light class items</returns>
        Task<List<Light>> GetAllAsync();

        /// <summary>
        /// Function to get singular Light class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Light class item, possibility for null</returns>
        Task<Light?> GetByIdAsync(int id);

        /// <summary>
        /// Function to get multiple Light class items, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Light class items</returns>
        Task<List<Light>> GetByRaspberryIdAsync(int id);

        /// <summary>
        /// Function to add singular Light class item, asynchronous
        /// </summary>
        /// <param name="light">Light class item</param>
        /// <returns>Light class item, possibility for null</returns>
        Task<Light?> AddLightAsync(Light light);


        /// <summary>
        /// Function to delete singular Light class item, asynchronous
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Light class item, possibility for null</returns>
        Task<Light?> DeleteLightAsync(int id);

        /// <summary>
        /// Function to delete multiple Light class items, asynchronous
        /// </summary>
        /// <returns>integer, number of affected rows</returns>
        Task<int> DeleteOlderThan90DaysAsync();
    }
}
