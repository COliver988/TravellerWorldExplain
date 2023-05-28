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

        [Test]
        [TestCase("A123456-7")]
        [TestCase("C123456-7")]
        public void World_Validation(string UWP)
        {
            world = new World(UWP);
            if (string.IsNullOrEmpty(UWP))
            {
                Assert.IsFalse(world.Is_Valid());
            }
            else if (world.Starport == "Z")
            {
                Assert.IsFalse(world.Is_Valid());
            }
            else
            {
                Assert.IsTrue(world.Is_Valid());
            }
        }

        [Test]
        [TestCase(null)]
        [TestCase("Z123456-7")]
        public void World_Is_Invalid(string UWP)
        {
            world = new World(UWP);
            if (string.IsNullOrEmpty(UWP))
            {
                Assert.IsFalse(world.Is_Valid());
            }
            else if (world.Starport == "Z")
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