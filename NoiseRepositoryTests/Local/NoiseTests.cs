using ClassLibrary.Models;
namespace RepositoryTests.Local;

[TestClass]
public class NoiseTests
{
    [TestMethod]
    [DataRow(1, 1, 60.5, "2025-12-01", "09:30:05")]
    [DataRow(2, 1, 70, "2025-12-01", "10:30:01")]
    [DataRow(3, 1, 55, "2025-12-01", "11:30:19")]
    [DataRow(4, 1, 67.5, "2025-12-01", "18:30:13")]
    public void CreateNoise(int id, int raspberryid, double decibel, string strTime, string strDate)
    {
        // Arrange
        TimeOnly time = TimeOnly.Parse(strTime);
        DateOnly date = DateOnly.Parse(strDate);
        Noise n = new Noise(id, raspberryid, decibel, time, date);
        

        // Act
        string actualTime = n.Time.ToString("yyyy-MM-dd");
        string actualDate = n.Date.ToString("HH:mm:ss");

        // Assert
        Assert.AreEqual(n.Id, id);
        Assert.AreEqual(n.RaspberryId, raspberryid);
        Assert.AreEqual(n.Decibel, decibel);
        Assert.AreEqual(actualTime, strTime);
        Assert.AreEqual(actualDate, strDate);
    }

    [TestMethod]
    public void ReadNoise()
    {
    }
    [TestMethod]
    public void UpdateNoise()
    {
    }
    [TestMethod]
    public void DeleteNoise()
    {
    }
}
