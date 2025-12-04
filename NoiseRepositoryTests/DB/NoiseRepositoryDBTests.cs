using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using ClassLibrary.Services.DB;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepositoryTests;

[TestClass]
public class NoiseRepositoryDBTests
{
    [TestMethod]
    public async Task GetAllTest_Successfull()
    {
        // Arrange
        INoiseRepositoryDB repo = new NoiseRepositoryDB();

        // Act
        List<Noise> noises = await repo.GetAllAsync();

        // Assert
        Assert.AreNotEqual(0, noises.Count);
    }

    [TestMethod]
    public async Task GetByIdTest_Successfull()
    {
        // Arrange
        int id = 1;
        INoiseRepositoryDB repo = new NoiseRepositoryDB();

        // Act
        Noise? noise = await repo.GetByIdAsync(id);

        // Assert
        Assert.IsNotNull(noise);
        Assert.AreEqual(id, noise.Id);
    }

    [TestMethod()]
    public async Task AddTest_Successfull()
    {
        // Arrange
        INoiseRepositoryDB repo = new NoiseRepositoryDB();
        DateTime now = DateTime.Now;

        // Act
        Noise noise = new Noise();
        noise.Time = TimeOnly.FromDateTime(now);
        noise.Date = DateOnly.FromDateTime(now);
        Noise? addedNoise = await repo.AddNoiseAsync(noise);

        // Assert
        Assert.IsNotNull(addedNoise);

        // Cleanup
        await repo.DeleteNoiseAsync(addedNoise.Id);
    }

    [TestMethod]
    public async Task DeleteTest_Successfull()
    {
        // Arrange
        INoiseRepositoryDB repo = new NoiseRepositoryDB();

        // Act
        Noise noise = new Noise();
        DateTime now = DateTime.Now;
        noise.Time = TimeOnly.Parse($"{now.Hour}:{now.Minute}:{now.Second}");
        noise.Date = DateOnly.Parse($"{now.Date}");
        Noise? noiseAdded = await repo.AddNoiseAsync(noise);
        Noise? noiseDeleted = await repo.DeleteNoiseAsync(noiseAdded.Id);

        // Assert
        Assert.IsNotNull(noiseAdded);
        Assert.IsNotNull(noiseDeleted);
    }
}
