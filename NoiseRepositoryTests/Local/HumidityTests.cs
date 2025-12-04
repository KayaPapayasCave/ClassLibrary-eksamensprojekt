using ClassLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace RepositoryTests
{
    [TestClass]
    public class HumidityTests
    {
        [DataTestMethod] // Must use DataTestMethod for DataRow
        [DataRow(1, 2, 23.6, "2025-07-13", "14:47")]
        [DataRow(1, 56, 36.6, "2025-08-27", "12:57")]
        [DataRow(1, 78, 44.6, "2025-08-16", "09:27")]
        [DataRow(1, 46, 33.4, "2025-09-08", "17:15")]
        [DataRow(1, 89, 29.9, "2025-10-11", "06:45")]
        public void TestMethod1(int id, int raspberryId, double humidityPercent, string strDate, string strTime)
        {
            // Arrange
            DateOnly date = DateOnly.Parse(strDate);
            TimeOnly time = TimeOnly.Parse(strTime);
            Humidity h = new Humidity(id, raspberryId, humidityPercent, date, time);

            // Act
            string actualDate = h.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string actualTime = h.Time.ToString("HH:mm", CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual(id, h.Id);
            Assert.AreEqual(raspberryId, h.RaspberryId);
            Assert.AreEqual(humidityPercent, h.HumidityPercent);
            Assert.AreEqual(strDate, actualDate);
            Assert.AreEqual(strTime, actualTime);
        }
    }
}
