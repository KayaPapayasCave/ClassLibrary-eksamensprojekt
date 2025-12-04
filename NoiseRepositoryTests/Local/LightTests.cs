using ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace RepositoryTests
{
    [TestClass]
    public class LightTests
    {
        [TestMethod]
        [DataRow(1, 2, 5000.4, "2025-05-07", "13:56")]
        [DataRow(1, 3, 679.2, "2025-11-09", "12:34")]
        [DataRow(1, 14, 2345.7, "2025-01-21", "09:15")]
        [DataRow(1, 87, 3987.89, "2025-05-28", "19:34")]
        [DataRow(1, 67, 1987.34, "2025-10-16", "05:28")]
        public void TestMethod1(int id, int raspberryId, double lumen, string strDate, string strTime)
        {
            // Arrange
            DateOnly date = DateOnly.Parse(strDate);
            TimeOnly time = TimeOnly.Parse(strTime);
            Light l = new Light(id, raspberryId, lumen, date, time);

            // Act
            string actualDate = l.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string actualTime = l.Time.ToString("HH:mm", CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual(id, l.Id);
            Assert.AreEqual(raspberryId, l.RaspberryId);
            Assert.AreEqual(lumen, l.Lumen);
            Assert.AreEqual(strDate, actualDate);
            Assert.AreEqual(strTime, actualTime);
        }
    }
}
