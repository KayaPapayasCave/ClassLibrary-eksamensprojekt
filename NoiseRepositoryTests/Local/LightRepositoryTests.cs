using ClassLibrary.Interfaces.Local;
using ClassLibrary.Models;
using ClassLibrary.Services.Local;
namespace RepositoryTests.Local;

[TestClass]
public class LightRepositoryTests
{
    [TestMethod]
    [DataRow()]
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
        List<Light> light = repo.GetByRaspberryId(1);

        // Assert
        Assert.AreNotEqual(0, light.Count);
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
