using ClassLibrary.Models;
using System;
namespace RepositoryTests;

[TestClass]
public class HumidityTests
{
    [TestMethod]

    [DataRow(1,2, 23.6,"2025-07-13","14:47")]
    [DataRow(1,56,36.6,"2025-08-27","12:57")]
    [DataRow(1,78,44.6,"2025-08-16","09:27")]
    [DataRow(1,46,33.4,"2025-09-08","17:15")]
    [DataRow(1,89,29.9,"2025-10-11","06:45")]

    public void TestMethod1(int id,int rasberryId,double humidity, string strDate, string strTime)
    {
        //arrange
        TimeOnly time = TimeOnly.Parse(strTime);
        DateOnly date = DateOnly.Parse(strDate);
        Humidity h = new Humidity(id,rasberryId, humidity,date,time);

        //act
        string actualTime = h.Time.ToString("yyyy-MM-dd");
        string actualDate = h.Date.ToString("HH:mm:ss");

        // Assert
        Assert.AreEqual(h.Id, id);
        Assert.AreEqual(h.RaspberryId, rasberryId);
        Assert.AreEqual(h.HumidityPercent, humidity);
        Assert.AreEqual(actualTime, strTime);
        Assert.AreEqual(actualDate, strDate);

    }
}
