using ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace RepositoryTests;

[TestClass]
public class TemperatureTests
{
    [TestMethod]
    [DataRow(1, 65, 45.7, "2025-02-15", "16:12")]
    [DataRow(1, 80, 78.2, "2025-04-24", "08:54")]
    [DataRow(1, 56, 48.1, "2025-05-27", "21:45")]
    [DataRow(1, 67, 38.7, "2025-04-28", "11:54")]
    [DataRow(1, 92, 33.5, "2025-11-05", "17:54")]
    public void TestMethod1(int id, int raspberryId, double celsius, string strDate, string strTime)
    {
        // Arrange
        DateOnly date = DateOnly.Parse(strDate);
        TimeOnly time = TimeOnly.Parse(strTime);
        Temperature t = new Temperature(id, raspberryId, celsius, date, time);

        // Act
        string actualDate = t.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        string actualTime = t.Time.ToString("HH:mm", CultureInfo.InvariantCulture);

        // Assert
        Assert.AreEqual(id, t.Id);
        Assert.AreEqual(raspberryId, t.RaspberryId);
        Assert.AreEqual(celsius, t.Celsius);
        Assert.AreEqual(strDate, actualDate);
        Assert.AreEqual(strTime, actualTime);
    }
}
