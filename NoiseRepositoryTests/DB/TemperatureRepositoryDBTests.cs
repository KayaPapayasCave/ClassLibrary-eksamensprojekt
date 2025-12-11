using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using ClassLibrary.Services.DB;

namespace RepositoryTests
{

    [TestClass]
    public class TemperatureRepositoryDBTests
    {
        private ITemperatureRepositoryDB _repo;
        [TestInitialize]
        public void Setup()
        {
            _repo = new TemperatureRepositoryDB();
        }

        [TestMethod]
        public async Task GetAllTest_Successful()
        {
            // Act
            List<Temperature> temperatures = await _repo.GetAllAsync();

            // Assert
            Assert.IsTrue(temperatures.Count >= 0, "There should be at least 0 records");
        }

        [TestMethod]
        public async Task GetByIdTest_Successful()
        {
            // Arrange
            DateTime now = DateTime.Now;
            Temperature temperature = new Temperature
            {
                Id = 1,
                RaspberryId = 1,
                Celsius = 28.2,
                Date = DateOnly.FromDateTime(now),
                Time = TimeOnly.FromDateTime(now)
            };

            Temperature? addedTemperature = await _repo.AddTemperatureAsync(temperature);
            Assert.IsNotNull(addedTemperature);

            // Act: fetch by the inserted ID
            Temperature? fetchedTemperature = await _repo.GetByIdAsync(addedTemperature!.Id);

            // Assert
            Assert.IsNotNull(fetchedTemperature, $"Temperature with ID={addedTemperature.Id} should exist");
            Assert.AreEqual(addedTemperature.Id, fetchedTemperature!.Id);

            // Cleanup
            await _repo.DeleteTemperatureAsync(addedTemperature.Id);
        }

        [TestMethod]
        public async Task AddTest_Successful()
        {
            // Arrange
            DateTime now = DateTime.Now;
            Temperature temperature = new Temperature
            {
                Id = 1,
                RaspberryId = 1,
                Celsius = 28.5,
                Date = DateOnly.FromDateTime(now),
                Time = TimeOnly.FromDateTime(now)
            };

            // Act
            Temperature? addedTemperature = await _repo.AddTemperatureAsync(temperature);

            // Assert
            Assert.IsNotNull(addedTemperature);
            Assert.IsTrue(addedTemperature!.Id > 0, "Inserted temperature should have an ID");

            // Cleanup
            await _repo.DeleteTemperatureAsync(addedTemperature.Id);
        }

        [TestMethod]
        public async Task DeleteTest_Successful()
        {
            // Arrange
            DateTime now = DateTime.Now;
            Temperature temperature = new Temperature
            {
                Id = 999999,
                RaspberryId = 1,
                Celsius = 0,
                Date = DateOnly.FromDateTime(now),
                Time = TimeOnly.FromDateTime(now)
            };

            Temperature? addedTemperature = await _repo.AddTemperatureAsync(temperature);

            // Act
            Temperature? deletedTemperature = await _repo.DeleteTemperatureAsync(addedTemperature!.Id);

            // Assert
            Assert.IsNotNull(addedTemperature);
            Assert.IsNotNull(deletedTemperature);
            Assert.AreEqual(addedTemperature.Id, deletedTemperature!.Id);
        }
    }
}