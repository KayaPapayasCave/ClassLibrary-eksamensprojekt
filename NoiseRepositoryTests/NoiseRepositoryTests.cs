using ClassLibrary;

namespace NoiseRepositoryTests
{
    [TestClass]
    public sealed class NoiseRepositoryTests
    {
        [TestMethod]
        public void HighNoiseAlert_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            repo.Noise();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void MediumNoiseMessage_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            repo.Noise();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void LowNoiseMessage_Success()
        {
            // Arrange
            INoiseRepository repo = new NoiseRepository();

            // Act
            repo.Noise();

            // Assert
            Assert.Fail();
        }
    }
}
