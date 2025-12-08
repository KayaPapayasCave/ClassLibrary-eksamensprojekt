using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;

namespace ClassLibrary.Services.Local
{
    /// <summary>
    /// A repository class for managing Noise data.
    /// </summary>
    public class NoiseRepository : INoiseRepository
    {
        /// <summary>
        /// A private list to store Noise objects.
        /// </summary>
        private List<Noise> _noises;

        /// <summary>
        /// An empty constructor that initializes the NoiseRepository with some sample data.
        /// </summary>
        public NoiseRepository()
        {
            DateTime now = DateTime.Now;
            
            _noises = new List<Noise>
            {
                new Noise
                {
                    Id = 0,
                    RaspberryId = 1,
                    Decibel = 35,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)

                },
                new Noise
                {
                    Id = 1,
                    RaspberryId = 1,
                    Decibel = 39,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
                new Noise
                {
                    Id = 2,
                    RaspberryId = 1,
                    Decibel = 44,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
                new Noise
                {
                    Id = 3,
                    RaspberryId = 1,
                    Decibel = 40,
                    Time = TimeOnly.FromDateTime(now),
                    Date = DateOnly.FromDateTime(now)
                },
            };
        }

        /// <summary>
        /// A method to get all Noise objects.
        /// </summary>
        public List<Noise> GetAll()
        {
            return _noises;
        }

        /// <summary>
        /// A method to get a Noise object by its ID.
        /// </summary>
        public Noise? GetById(int id)
        {
            foreach (var noise in _noises)
            {
                if (noise.Id == id)
                {
                    return noise;
                }
            }
            return null;
        }

        /// <summary>
        /// A method to get Noise objects by Raspberry ID, and returns a list.
        /// </summary>
        public List<Noise> GetByRaspberryId(int id)
        {
            List<Noise> noisList = new List<Noise>();
            foreach (var noise in _noises)
            {
                if (noise.RaspberryId == id)
                {
                    noisList.Add(noise);
                }
            }
            return noisList;
        }

        /// <summary>
        /// A method to add a new Noise object.
        /// </summary>
        public Noise? AddNoise(Noise noise)
        {
            _noises.Add(noise);
            return noise;
        }

        /// <summary>
        /// A method to delete a Noise object by its ID.
        /// </summary>
        public Noise? DeleteNoise(int id)
        {
            Noise? noise = GetById(id);
            if (noise == null) return null;
            _noises.Remove(noise);
            return noise;
        }

        /// <summary>
        /// A method to update an existing Noise object.
        /// </summary>
        public Noise? UpdateNoise(Noise noise)
        {
            Noise? oldNoise = GetById(noise.Id);
            if (oldNoise == null) return null;
            oldNoise.RaspberryId = noise.RaspberryId;
            oldNoise.Decibel = noise.Decibel;
            oldNoise.Time = noise.Time;
            return noise;
        }
    }
}
