using NUnit.Framework;
using Star_Wars;
using Star_Wars.DTO;
using Star_Wars.Helper;
namespace StarWarsUnitTest
{
    public class Tests
    {
        [Test]
        public void CalculateResupplyFreq()
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
        public void GetResponseApi()
        {
            RequestBase<ResponseDTO> req = new RequestBase<ResponseDTO>();
            try
            {
                var list = req.CallApi("https://swapi.dev/api/starships/?page=1");
                Assert.IsTrue(list != null);
            }
            catch (System.Exception)
            {

                Assert.IsTrue(false);
            }

        }
    }
}