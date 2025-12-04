using ClassLibrary.Models;
using System;
using System.Globalization;
namespace RepositoryTests.Local;

[TestClass]
public class NoiseTests
{
    [TestMethod]
    [DataRow(1, 1, 60.5, "2025-12-01", "09:30:05")]
    [DataRow(2, 1, 70, "2025-12-01", "10:30:01")]
    [DataRow(3, 1, 55, "2025-12-01", "11:30:19")]
    [DataRow(4, 1, 67.5, "2025-12-01", "18:30:13")]
    public void CreateAndReadNoise(int id, int rasberryId, double decibel, string strDate, string strTime)
    {
        // Arrange
        TimeOnly time = TimeOnly.Parse(strTime);
        DateOnly date = DateOnly.Parse(strDate);
        Noise n = new Noise(id, rasberryId, decibel, date, time);

        // Act
        string actualDate = n.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        string actualTime = n.Time.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

        // Assert
        Assert.AreEqual(n.Id, id);
        Assert.AreEqual(n.RaspberryId, rasberryId);
        Assert.AreEqual(n.Decibel, decibel);
        Assert.AreEqual(actualTime, strTime);
        Assert.AreEqual(actualDate, strDate);
    }
}
