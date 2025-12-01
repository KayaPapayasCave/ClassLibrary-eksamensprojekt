using ClassLibrary.Services;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace NoiseRepositoryTests
{
    [TestClass]
    public sealed class NoiseRepositoryTests
    {
        [TestMethod]
        public void GetAllNoises_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            List<Noise> noises = repo.GetAll();

            // Assert
            Assert.AreNotEqual(0, noises.Count);
        }

        [TestMethod]
        public void GetNoiseById_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            Noise? noise = repo.GetById(0);

            // Assert
            Assert.IsNotNull(noise);
        }

        [TestMethod]
        public void AddNoise_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            Noise? noise = repo.AddNoise(new Noise());

            // Assert
            Assert.IsNotNull(noise);
        }

        [TestMethod]
        public void DeleteNoise_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            Noise? noise = repo.DeleteNoise(0);

            // Assert
            Assert.IsNotNull(noise);
        }

        [TestMethod]
        public void UpdateNoise_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            Noise? noise = repo.UpdateNoise(new Noise());

            // Assert
            Assert.IsNotNull(noise);
        }
    }
}
