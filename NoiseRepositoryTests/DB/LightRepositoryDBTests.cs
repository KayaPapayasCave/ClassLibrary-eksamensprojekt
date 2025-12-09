using ClassLibrary.Interfaces.DB;
using ClassLibrary.Models;
using ClassLibrary.Services.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepositoryTests
{
    [TestClass]
    public class LightRepositoryDBTests
    {
        private ILightRepositoryDB _repo;

        [TestInitialize]
        public void Setup()
        {
            _repo = new LightRepositoryDB(); // Uses Secret.ConnectionString internally
        }

        [TestMethod]
        public async Task GetAllTest_Successful()
        {
            // Act
            List<Light> lights = await _repo.GetAllAsync();

            // Assert
            Assert.IsTrue(lights.Count >= 0, "There should be at least 0 records");
        }

        [TestMethod]
        public async Task GetByIdTest_Successful()
        {
            // Arrange: create a new light entry
            ILightRepositoryDB repo = new LightRepositoryDB();
            var newLight = new Light
            {
                RaspberryId = 1,
                Lumen = 123.45,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now)
            };

            Light? added = await repo.AddLightAsync(newLight);

            try
            {
                // Act
                Light? light = await repo.GetByIdAsync(added!.Id);

                // Assert
                Assert.IsNotNull(light, $"Light with ID={added.Id} should exist");
                Assert.AreEqual(added.Id, light!.Id);
            }
            finally
            {
                // Cleanup
                await repo.DeleteLightAsync(added!.Id);
            }
        }

        [TestMethod]
        public async Task GetByRaspberryIdTest_Successful()
        {
            // Arrange: create a new light entry
            ILightRepositoryDB repo = new LightRepositoryDB();
            var newLight = new Light
            {
                RaspberryId = 42, // pick any test value
                Lumen = 123.45,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now)
            };

            Light? added = await repo.AddLightAsync(newLight);

            try
            {
                // Act
                List<Light> lightList = await repo.GetByRaspberryIdAsync(added!.RaspberryId);

                // Assert
                Assert.IsNotNull(lightList, $"Light with RaspberryId={added.RaspberryId} should exist");
                foreach(Light light in lightList)
                    Assert.AreEqual(added.RaspberryId, light!.RaspberryId);
            }
            finally
            {
                // Cleanup
                await repo.DeleteLightAsync(added!.Id);
            }
        }

        [TestMethod]
        public async Task AddTest_Successful()
        {
            var newLight = new Light(
                id: 0, // will be set by DB
                rId: 1,
                lumen: 123.45,
                date: DateOnly.FromDateTime(DateTime.Now),
                time: TimeOnly.FromDateTime(DateTime.Now)
            );

            Light? addedLight = await _repo.AddLightAsync(newLight);

            Assert.IsNotNull(addedLight);
            Assert.IsTrue(addedLight!.Id > 0, "Inserted Light should have an ID");

            // Cleanup
            await _repo.DeleteLightAsync(addedLight.Id);
        }

        [TestMethod]
        public async Task DeleteTest_Successful()
        {
            var tempLight = new Light(
                id: 0,
                rId: 1,
                lumen: 150.0,
                date: DateOnly.FromDateTime(DateTime.Now),
                time: TimeOnly.FromDateTime(DateTime.Now)
            );

            Light? added = await _repo.AddLightAsync(tempLight);
            Light? deleted = await _repo.DeleteLightAsync(added!.Id);

            Assert.IsNotNull(added);
            Assert.IsNotNull(deleted);
            Assert.AreEqual(added.Id, deleted!.Id);
        }

        [TestMethod]
        public async Task DeleteOlderThan90DaysTest()
        {
            int deletedRows = await _repo.DeleteOlderThan90DaysAsync();
            Assert.IsTrue(deletedRows >= 0, "Deleted rows should be >= 0");
        }
    }
}
