using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using ClassLibrary.Services.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryTests
{
    [TestClass]
    public class NoiseRepositoryDBTests
    {
        private INoiseRepositoryDB _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new NoiseRepositoryDB();
        }

        [TestMethod]
        public async Task GetAllTest_Successful()
        {
            // Act
            List<Noise> noises = await _repo.GetAllAsync();

            // Assert
            Assert.IsTrue(noises.Count >= 0, "There should be at least 0 records");
        }

        [TestMethod]
        public async Task GetByIdTest_Successful()
        {
            INoiseRepositoryDB repo = new NoiseRepositoryDB();

            // Arrange: insert a row to ensure it exists
            Noise noise = new Noise
            {
                RaspberryId = 1,
                Decibel = 60.5,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now)
            };

            Noise? addedNoise = await repo.AddNoiseAsync(noise);
            Assert.IsNotNull(addedNoise);

            // Act: fetch by the inserted ID
            Noise? fetchedNoise = await repo.GetByIdAsync(addedNoise!.Id);

            // Assert
            Assert.IsNotNull(fetchedNoise, $"Noise with ID={addedNoise.Id} should exist");
            Assert.AreEqual(addedNoise.Id, fetchedNoise!.Id);

            // Cleanup
            await repo.DeleteNoiseAsync(addedNoise.Id);
        }


        [TestMethod]
        public async Task AddTest_Successful()
        {
            // Arrange
            DateTime now = DateTime.Now;
            Noise noise = new Noise
            {
                Date = DateOnly.FromDateTime(now),
                Time = TimeOnly.FromDateTime(now)
            };

            // Act
            Noise? addedNoise = await _repo.AddNoiseAsync(noise);

            // Assert
            Assert.IsNotNull(addedNoise);
            Assert.IsTrue(addedNoise!.Id > 0, "Inserted noise should have an ID");

            // Cleanup
            await _repo.DeleteNoiseAsync(addedNoise.Id);
        }

        [TestMethod]
        public async Task DeleteTest_Successful()
        {
            // Arrange
            DateTime now = DateTime.Now;
            Noise noise = new Noise
            {
                Date = DateOnly.FromDateTime(now),
                Time = TimeOnly.FromDateTime(now)
            };

            Noise? addedNoise = await _repo.AddNoiseAsync(noise);

            // Act
            Noise? deletedNoise = await _repo.DeleteNoiseAsync(addedNoise!.Id);

            // Assert
            Assert.IsNotNull(addedNoise);
            Assert.IsNotNull(deletedNoise);
            Assert.AreEqual(addedNoise.Id, deletedNoise!.Id);
        }
    }
}
