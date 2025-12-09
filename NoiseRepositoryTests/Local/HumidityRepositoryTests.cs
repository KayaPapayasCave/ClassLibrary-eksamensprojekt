using ClassLibrary;
using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using ClassLibrary.Services.Local;
namespace RepositoryTests.Local;

[TestClass]
public class HumidityRepositoryTests
{
    [TestMethod]
    public void GetAllHumidity_Success()
    {
        // Arrange
        IHumidityRepository repo = new HumidityRepository();

        // Act
        List<Humidity> humidity = repo.GetAll();

        // Assert
        Assert.AreNotEqual(0, humidity.Count);
    }

    [TestMethod]
    public void GetHumidityById_Success()
    {
        // Arrange
        IHumidityRepository repo = new HumidityRepository();

        // Act
        Humidity? humidity = repo.GetById(0);

        // Assert
        Assert.IsNotNull(humidity);
    }

    [TestMethod]
    public void GetHumidityByRaspberryId_Success()
    {
        // Arrange
        IHumidityRepository repo = new HumidityRepository();

        // Act
        List<Humidity> humidity = repo.GetByRaspberryId(1);

        // Assert
        Assert.AreNotEqual(0, humidity.Count);
    }

    [TestMethod]
    public void AddHumidity_Success()
    {
        // Arrange
        IHumidityRepository repo = new HumidityRepository();

        // Act
        Humidity? humidity = repo.AddHumidity(new Humidity());

        // Assert
        Assert.IsNotNull(humidity);
    }

    [TestMethod]
    public void DeleteHumidity_Success()
    {

    }

    [TestMethod]
    public void UpdateHumidity_Success()
    {

    }
}
