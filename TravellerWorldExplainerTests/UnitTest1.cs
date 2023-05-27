using TravellerWorldExplain;
using NUnit.Framework;
using TravellerWorldExplain.Models;

namespace TravellerWorldExplainerTests
{
    [TestFixture]
    public class WorldTests
    {
        private World world;

        [SetUp]
        public void Setup()
        {
            world = new World();
        }

        [TestCase(null)]
        [TestCase("A123456-7")]
        public void World_Should_Be_Valid(string UWP)
        {
            world = new World(UWP);
            if (string.IsNullOrEmpty(UWP))
            {
                Assert.IsFalse(world.Is_Valid());
            }
            else
            {
                Assert.IsTrue(world.Is_Valid());
            }
        }
    }
}