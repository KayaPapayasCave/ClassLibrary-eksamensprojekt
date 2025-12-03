using ClassLibrary.Models;
using System;

namespace RepositoryTests;

[TestClass]
public class TemperatureTests
{
    [TestMethod]
    [DataRow(1,65,45.7,"2025-02-15","16:12")]
    [DataRow(1,80,78.2,"2025-04-24","08:54")]
    [DataRow(1,56,48.1,"2025-05-27","21:45")]
    [DataRow(1,67,38.7,"2025-04.28","11:54")]
    [DataRow(1,92,33.5,"2025-11-05","17:54")]
    public void TestMethod1(int id, int rasberryId, double celsius, string strDate, string strTime)
    {
        //arrange
        TimeOnly time = TimeOnly.Parse(strTime);
        DateOnly date = DateOnly.Parse(strDate);
        Temperature t = new Temperature(id,rasberryId,celsius, date,time);

        //act
        string actualTime = t.Time.ToString("yyyy-MM-dd");
        string actualDate = t.Date.ToString("HH:mm:ss");

        // Assert
        Assert.AreEqual(t.Id, id);
        Assert.AreEqual(t.RaspberryId, rasberryId);
        Assert.AreEqual(t.Celsius, celsius);
        Assert.AreEqual(actualTime, strTime);
        Assert.AreEqual(actualDate, strDate);
        
    }
}
