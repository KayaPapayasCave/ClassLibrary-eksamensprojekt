using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.Local
{
    /// <summary>
    /// Interface class for Noise Repository classes
    /// </summary>
    public interface INoiseRepository
    {
        /// <summary>
        /// Function to get all Noise class items
        /// </summary>
        /// <returns>List of Noise class items</returns>
        List<Noise> GetAll();

        /// <summary>
        /// Function to get singular Noise class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Noise class item, can be null</returns>
        Noise? GetById(int id);

        /// <summary>
        /// Function to get multiple Noise class items
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>List of Noise class items</returns>
        List<Noise> GetByRaspberryId(int id);

        /// <summary>
        /// Function to add singular Noise class item
        /// </summary>
        /// <param name="noise">Noise class item</param>
        /// <returns>Noise class item, can be null</returns>
        Noise? AddNoise(Noise noise);

        /// <summary>
        /// Function to delete singular Noise class item
        /// </summary>
        /// <param name="id">integer</param>
        /// <returns>Noise class item, can be null</returns>
        Noise? DeleteNoise(int id);

        /// <summary>
        /// Function to update singular Noise class item
        /// </summary>
        /// <param name="noise">Noise class item</param>
        /// <returns>Noise class item, can be null</returns>
        Noise? UpdateNoise(Noise noise);
    }
}
