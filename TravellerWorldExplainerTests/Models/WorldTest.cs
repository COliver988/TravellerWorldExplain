using TravellerWorldExplain.Models;
using TravellerWorldExplain.Services;

namespace TravellerWorldExplainerTests.Models
{
    [TestFixture]
    public class WorldTests
    {
        private World world;
        private WorldService worldService = new WorldService();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("A123456-7")]
        [TestCase("B987AA9-F")]
        [TestCase("C123456-7")]
        [TestCase("AAAAAA9-A")]
        public void World_Is_Valid(string UWP)
        {
            world = new World(UWP);
            Assert.That(world.Is_Valid());
        }

        [Test]
        [TestCase(null)]
        [TestCase("Z123456-7")]
        [TestCase("A123456-K")]
        public void World_Is_Invalid(string UWP)
        {
            world = new World(UWP);
            Assert.That(world.Is_Valid(), Is.False);
        }
    }
}