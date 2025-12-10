using ClassLibrary.Interfaces.DB;
using ClassLibrary.Services.DB;

namespace RepositoryTests;

[TestClass]
public class TemperatureRepositoryDBTests
{
    private ITemperatureRepositoryDB _repo;
    [TestInitialize]
    public void Setup()
    {
        _repo = new TemperatureRepositoryDB();
    }

    [TestMethod]
    public void TestMethod1()
    {
    }
}