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
        }

        [Test]
        [TestCase("A123456-7")]
        [TestCase("B987AAA-F")]
        [TestCase("C123456-7")]
        [TestCase("AAAAAAA-A")]
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