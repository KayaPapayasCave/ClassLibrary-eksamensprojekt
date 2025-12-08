using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.Local
{
    /// <summary>
    /// Interface class for Temperature Repository classes
    /// </summary>
    public interface ITemperatureRepository
    {
        /// <summary>
        /// Function to fetch all Temperature class items
        /// </summary>
        /// <returns>List of Temperature class items</returns>
        List<Temperature> GetAll();

        /// <summary>
        /// Function to fetch singular Temperature class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Temperature class item, can be null</returns>
        Temperature? GetById(int id);

        /// <summary>
        /// Function to fetch multiple Temperature class items
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Temperature class items</returns>
        List<Temperature> GetByRaspberryId(int id);

        /// <summary>
        /// Function to add singular Temperature class item
        /// </summary>
        /// <param name="temperature">Temperature class item</param>
        /// <returns>Temperature class item, can be null</returns>
        Temperature? AddTemperature(Temperature temperature);

        /// <summary>
        /// Function to delete singular Temperature class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Temperature class item, can be null</returns>
        Temperature? DeleteTemperature(int id);

        /// <summary>
        /// Function to update singular Temperature class item
        /// </summary>
        /// <param name="temperature">Temperature class item</param>
        /// <returns>Temperature class item, can be null</returns>
        Temperature? UpdateTemperature(Temperature temperature);
    }
}
