using ClassLibrary.Models;
using System;

namespace RepositoryTests;

[TestClass]
public class LightTests
{
    [TestMethod]
    [DataRow(1,2,5000.4,"2025-05-07","13:56")]
    [DataRow(1,3,679.2,"2025-11-09","12:34")]
    [DataRow(1,14,2345.7,"2025-01-21","09:15")]
    [DataRow(1,87,3987.89,"2025-05-28","19:34")]
    [DataRow(1,67,1987.34,"2025-10-16","05:28")]
    public void TestMethod1(int id, int rasberryId, double lumen, string strDate, string strTime)
    {
        //arrange
        TimeOnly time = TimeOnly.Parse(strTime);
        DateOnly date = DateOnly.Parse(strDate);
        Light l = new Light(id, rasberryId, lumen,date,time);

        //act
        string actualTime = l.Time.ToString("yyyy-MM-dd");
        string actualDate = l.Date.ToString("HH:mm:ss");

        // Assert
        Assert.AreEqual(l.Id, id);
        Assert.AreEqual(l.RaspberryId, rasberryId);
        Assert.AreEqual(l.Lumen, lumen);
        Assert.AreEqual(actualTime, strTime);
        Assert.AreEqual(actualDate, strDate);
        
    }
}
