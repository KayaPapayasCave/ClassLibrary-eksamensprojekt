using ClassLibrary;
using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using ClassLibrary.Services.Local;
namespace RepositoryTests.Local;

[TestClass]
public class TemperatureRepositoryTests
{
    [TestMethod]
    public void GetAllTemperature_Success()
    {
        // Arrange
        ITemperatureRepository repo = new TemperatureRepository();

        // Act
        List<Temperature> temperatures = repo.GetAll();

        // Assert
        Assert.AreNotEqual(0, temperatures.Count);
    }

    [TestMethod]
    public void GetTemperatureById_Success()
    {
        // Arrange
        ITemperatureRepository repo = new TemperatureRepository();

        // Act
        Temperature? temperature = repo.GetById(0);

        // Assert
        Assert.IsNotNull(temperature);
    }

    [TestMethod]
    public void GetTemperatureByRaspberryId_Success()
    {
        // Arrange
        ITemperatureRepository repo = new TemperatureRepository();

        // Act
        List<Temperature> temperatures = repo.GetByRaspberryId(1);

        // Assert
        Assert.AreNotEqual(0, temperatures.Count);
    }

    [TestMethod]
    public void AddTemperature_Success()
    {
        // Arrange 
        ITemperatureRepository repo = new TemperatureRepository();

        // Act
        Temperature? temperature = repo.AddTemperature(new Temperature());

        // Assert
        Assert.IsNotNull(temperature);
    }

    [TestMethod]
    public void DeleteTemperature_Success()
    {
        // Arrange
        ITemperatureRepository repo = new TemperatureRepository();

        // Act
        Temperature? temperature = repo.DeleteTemperature(0);

        // Assert
        Assert.IsNotNull(temperature);
    }

    [TestMethod]
    public void UpdateTemperature_Success()
    {
        // Arrange
        ITemperatureRepository repo = new TemperatureRepository();

        // Act
        Temperature? temperature = repo.UpdateTemperature(new Temperature());

        // Assert
        Assert.IsNotNull(temperature);
    }
}
