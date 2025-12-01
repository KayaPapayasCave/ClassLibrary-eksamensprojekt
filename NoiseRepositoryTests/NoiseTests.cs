using ClassLibrary.Models;
namespace RepositoryTests;

[TestClass]
public class NoiseTests
{
    [TestMethod]
    [DataRow(1, 1, 60.5, "2025-12-01 09:30:05")]
    [DataRow(2, 1, 70, "2025-12-01 10:30:01")]
    [DataRow(3, 1, 55, "2025-12-01 11:30:19")]
    [DataRow(4, 1, 67.5, "2025-12-01 18:30:13")]
    public void CreateNoise(int id, int raspberryid, double decibel, string strTime)
    {
        // Arrange
        Noise n = new Noise();
        DateTime time = DateTime.Parse(strTime);

        // Act
        n.Id = id;
        n.RaspberryId = raspberryid;
        n.Decibel = decibel;
        n.Time = time;
        string actualTime = (n.Time).ToString("yyyy-MM-dd HH:mm:ss");

        // Assert
        Assert.AreEqual(n.Id, id);
        Assert.AreEqual(n.RaspberryId, raspberryid);
        Assert.AreEqual(n.Decibel, decibel);
        Assert.AreEqual(actualTime, strTime);
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
