using TravellerWorldExplain.Models;
using TravellerWorldExplain.Services;
using TravellerWorldExplainer.Services;

namespace TravellerWorldExplainerTests.Services
{
    [TestFixture]
    public class TravellerServiceBaseTest
    {
        private TravellerServiceBase _service = new TravellerServiceBase();

        [SetUp]

        public void SetUp() { }

        [Test]
        public void SingleDieRoll()
        {
            string dieRoll = "1D";
            int results = _service.calculateRoll(dieRoll);
            Assert.IsTrue(results >= 1 && results <= 6);
        }

        [Test]
        public void TwoDPlus4()
        {
            string dieRoll = "2D+4";
            int results = _service.calculateRoll(dieRoll);
            Assert.IsTrue(results >= 6 && results <= 16);
        }

        [Test]
        public void ThreeDMinusThree()
        {
            string dieRoll = "3D-3";
            int results = _service.calculateRoll(dieRoll);
            Assert.IsTrue(results >= 0 && results <= 15);
        }

        [Test]
        public void ThreeDMinusTwoD()
        {
            string dieRoll = "3D-2D";
            int results = _service.calculateRoll(dieRoll);
            Assert.IsTrue(results >= 0 && results <= 16);
        }

        [Test]
        public void Flux()
        {
            string dieRoll = "1D-1D";
            int results = _service.calculateRoll(dieRoll);
            Assert.IsTrue(results >= 0 && results <= 5);
        }

        [Test]
        public void NoDieRoll()
        {
            string dieRoll = "-";
            int results = _service.calculateRoll(dieRoll);
            Assert.IsTrue(results == 0);
        }
    }
}
