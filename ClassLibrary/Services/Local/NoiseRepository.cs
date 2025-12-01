using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;

namespace ClassLibrary.Services.Local
{
    public class NoiseRepository : INoiseRepository
    {
        private List<Noise> _noises;
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
                    Time = now
                },
                new Noise
                {
                    Id = 1,
                    RaspberryId = 1,
                    Decibel = 39,
                    Time = now.AddMinutes(-10)
                },
                new Noise
                {
                    Id = 2,
                    RaspberryId = 1,
                    Decibel = 44,
                    Time = now.AddMinutes(-20)
                },
                new Noise
                {
                    Id = 3,
                    RaspberryId = 1,
                    Decibel = 40,
                    Time = now.AddMinutes(-30)
                },
            };
        }

        public List<Noise> GetAll()
        {
            return _noises;
        }

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

        public Noise? GetByRaspberryId(int id)
        {
            foreach (var noise in _noises)
            {
                if (noise.RaspberryId == id)
                {
                    return noise;
                }
            }
            return null;
        }

        public Noise? AddNoise(Noise noise)
        {
            _noises.Add(noise);
            return noise;
        }

        public Noise? DeleteNoise(int id)
        {
            Noise? noise = GetById(id);
            if (noise == null) return null;
            _noises.Remove(noise);
            return noise;
        }

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
