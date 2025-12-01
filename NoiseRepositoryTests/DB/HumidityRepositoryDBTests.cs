using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using ClassLibrary.Services.DB;

namespace RepositoryTests;

[TestClass]
public class HumidityRepositoryDBTests
{
    [TestMethod]
    public async Task GetAllTest_Successfull()
    {
        // Arrange
        IHumidityRepositoryDB repo = new HumidityRepositoryDB();

        // Act
        List<Humidity> humidities = await repo.GetAllAsync();

        // Assert
        Assert.AreEqual(5, humidities.Count);
    }

    [TestMethod]
    public async Task GetByIdTest_Successfull()
    {
        // Arrange
        IHumidityRepositoryDB repo = new HumidityRepositoryDB();

        // Act
        Humidity? humidity = await repo.GetByIdAsync(2);

        // Assert
        Assert.IsNotNull(humidity);
        Assert.AreEqual(2, humidity.Id);
    }

    [TestMethod()]
    public async Task AddTest_Successfull()
    {
        // Arrange
        IHumidityRepositoryDB repo = new HumidityRepositoryDB();

        // Act
        Humidity? addedHumidity = await repo.AddHumidityAsync(new Humidity());

        // Assert
        Assert.IsNotNull(addedHumidity);

        // Cleanup
        await repo.DeleteHumidityAsync(addedHumidity.Id);
    }

    [TestMethod]
    public async Task DeleteTest_Successfull()
    {
        // Arrange
        IHumidityRepositoryDB repo = new HumidityRepositoryDB();

        // Act
        Humidity? humidityAdded = await repo.AddHumidityAsync(new Humidity());
        Humidity? humidtyDeleted = await repo.DeleteHumidityAsync(humidityAdded.Id);

        // Assert
        Assert.IsNotNull(humidityAdded);
        Assert.IsNotNull(humidtyDeleted);
    }
}
