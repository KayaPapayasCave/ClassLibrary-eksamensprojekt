using ClassLibrary;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Services;
namespace RepositoryTests;

[TestClass]
public class LightRepositoryTests
{
    [TestMethod]
    public void GetAllLight_Success()
    {
        // Arrange
        ILightRepository repo = new LightRepository();

        // Act
        List<Light> lights = repo.GetAll();

        // Assert
        Assert.AreNotEqual(0, lights.Count);
    }

    [TestMethod]
    public void GetLightById_Success()
    {
        // Arrange
        ILightRepository repo = new LightRepository();

        // Act
        Light? light = repo.GetById(0);

        // Assert
        Assert.IsNotNull(light);
    }

    [TestMethod]
    public void GetLightByRaspberryId_Success()
    {
        // Arrange
        ILightRepository repo = new LightRepository();

        // Act
        Light? light = repo.GetByRaspberryId(0);

        // Assert
        Assert.IsNotNull(light);
    }

    [TestMethod]
    public void AddLight_Success()
    {
        // Arrange
        ILightRepository repo = new LightRepository();

        // Act
        Light? light = repo.AddLight(new Light());

        // Assert
        Assert.IsNotNull(light);
    }

    [TestMethod]
    public void DeleteLight_Success()
    {
        // Arrange
        ILightRepository repo = new LightRepository();

        // Act
        Light? light = repo.DeleteLight(0);

        // Assert
        Assert.IsNotNull(light);
    }

    [TestMethod]
    public void UpdateLight_Success()
    {
        // Arrange
        ILightRepository repo = new LightRepository();

        // Act
        Light? light = repo.UpdateLight(new Light());

        // Assert
        Assert.IsNotNull(light);
    }

}
