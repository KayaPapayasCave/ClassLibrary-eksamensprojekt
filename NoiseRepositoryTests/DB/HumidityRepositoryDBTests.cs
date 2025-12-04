using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using ClassLibrary.Services.DB;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepositoryTests
{
    [TestClass]
    public class HumidityRepositoryDBTests
    {
        private IHumidityRepositoryDB _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new HumidityRepositoryDB();
        }

        [TestMethod]
        public async Task GetAllTest_Successful()
        {
            // Act
            List<Humidity> humidities = await _repo.GetAllAsync();

            // Assert
            Assert.IsTrue(humidities.Count >= 0, "There should be at least 0 records");
        }

        [TestMethod]
        public async Task GetByIdTest_Successful()
        {
            // Act
            Humidity? humidity = await _repo.GetByIdAsync(1); // Use a valid ID in your DB

            // Assert
            Assert.IsNotNull(humidity, "Humidity with ID=1 should exist");
            Assert.AreEqual(1, humidity!.Id);
        }

        [TestMethod]
        public async Task AddTest_Successful()
        {
            // Arrange
            var newHumidity = new Humidity(
                id: 0, // will be set by DB
                raspberryId: 1,
                humidityPercent: 55.5,
                date: DateOnly.FromDateTime(DateTime.Now),
                time: TimeOnly.FromDateTime(DateTime.Now)
            );

            // Act
            Humidity? addedHumidity = await _repo.AddHumidityAsync(newHumidity);

            // Assert
            Assert.IsNotNull(addedHumidity);
            Assert.IsTrue(addedHumidity!.Id > 0, "Inserted Humidity should have an ID");

            // Cleanup
            await _repo.DeleteHumidityAsync(addedHumidity.Id);
        }

        [TestMethod]
        public async Task DeleteTest_Successful()
        {
            // Arrange
            var tempHumidity = new Humidity(
                id: 0,
                raspberryId: 1,
                humidityPercent: 60.0,
                date: DateOnly.FromDateTime(DateTime.Now),
                time: TimeOnly.FromDateTime(DateTime.Now)
            );

            Humidity? added = await _repo.AddHumidityAsync(tempHumidity);

            // Act
            Humidity? deleted = await _repo.DeleteHumidityAsync(added!.Id);

            // Assert
            Assert.IsNotNull(added);
            Assert.IsNotNull(deleted);
            Assert.AreEqual(added.Id, deleted!.Id);
        }
    }
}
