using NUnit.Framework;
using Star_Wars;
using Star_Wars.DTO;
using Star_Wars.Helper;

namespace StarWarsUnitTest
{
    class TestHelper
    {
        [Test]
        public void TestCalculateResupplyFreq()
        {
            Bootstrap.Start();
            IMap MappingService = Bootstrap.container.GetInstance<IMap>();
            long Distance = 1000000;
            long resupply = (Distance / (12 * 30 * 24 * 75));
            var a = new StarshipDTO()
            {
                Consumables = "12 months",
                Manufacturer = "Turkish Army",
                Model = "KA-FA 1500",
                MGLT = "75",
                Name = "ATAKAN"
            };
            var result = MappingService.DoMap<StarshipDTO, Starship>(a);
            Assert.AreEqual(resupply, Helper.FindFreq(result.MGLT, result.Consumables, Distance));
        }
        [Test]
        public void TestCalculateResupplyFreqWrong()
        {
            Bootstrap.Start();
            IMap MappingService = Bootstrap.container.GetInstance<IMap>();
            long Distance = 1000000000;
            long resupply = (Distance / (12 * 30 * 24 * 75));
            var a = new StarshipDTO()
            {
                Consumables = "12 months",
                Manufacturer = "Turkish Army",
                Model = "KA-FA 1500",
                MGLT = "70",
                Name = "ATAKAN"
            };
            var result = MappingService.DoMap<StarshipDTO, Starship>(a);
            Assert.AreNotEqual(resupply, Helper.FindFreq(result.MGLT, result.Consumables, Distance));
        }
        [Test]
        public void TestValidInput()
        {
            Assert.AreEqual(10, Helper.ValidInput("10"));
        }
        [Test]
        public void TestUnValidInput()
        {
            Assert.AreNotEqual(10, Helper.ValidInput("asn"));
        }
    }
}