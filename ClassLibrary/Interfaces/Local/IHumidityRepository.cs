using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.Local
{
    /// <summary>
    /// Interface class for Humidity Repository classes
    /// </summary>
    public interface IHumidityRepository
    {
        /// <summary>
        /// Function to get all Humidity class items
        /// </summary>
        /// <returns>List of Humidity class items</returns>
        List<Humidity> GetAll();

        /// <summary>
        /// Function to get singular Humidity class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Humidity class item, can be null</returns>
        Humidity? GetById(int id);

        /// <summary>
        /// Function to get multiple Humidity class items
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Humidity class items</returns>
        List<Humidity> GetByRaspberryId(int id);

        /// <summary>
        /// Function to add singular Humidity class item
        /// </summary>
        /// <param name="humidity">Humidity class item</param>
        /// <returns>Humidity class item, can be null</returns>
        Humidity? AddHumidity(Humidity humidity);

        /// <summary>
        /// Function to delete singular Humidity class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Humidity class item, can be null</returns>
        Humidity? DeleteHumidity(int id);

        /// <summary>
        /// Function to update singular Humidity class item
        /// </summary>
        /// <param name="humidity">Humidity class item</param>
        /// <returns>Humidity class item, can be null</returns>
        Humidity? UpdateHumidity(Humidity humidity);
    }
}
