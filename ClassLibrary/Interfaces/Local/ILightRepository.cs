using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.Local
{
    /// <summary>
    /// Interface class for Light Repository classes
    /// </summary>
    public interface ILightRepository
    {
        /// <summary>
        /// Function to get all Light class items
        /// </summary>
        /// <returns>List of Light class items</returns>
        List<Light> GetAll();

        /// <summary>
        /// Function to get singular Light class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Light class item, can be null</returns>
        Light? GetById(int id);

        /// <summary>
        /// Function to get multiple Light class items, by Raspberry-Id
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Light class items</returns>
        List<Light> GetByRaspberryId(int id);

        /// <summary>
        /// Function to add singular Light class item
        /// </summary>
        /// <param name="light">Light class item</param>
        /// <returns>Light class item, can be null</returns>
        Light? AddLight(Light light);

        /// <summary>
        /// Function to delete singular Light class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Light class item, can be null</returns>
        Light? DeleteLight(int id);

        /// <summary>
        /// Function to update singular Light class item
        /// </summary>
        /// <param name="light">Light class item</param>
        /// <returns>Light class item, can be null</returns>
        Light? UpdateLight(Light light);
    }
}
