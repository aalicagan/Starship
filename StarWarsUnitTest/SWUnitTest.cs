using AutoMapper;
using NUnit.Framework;
using Star_Wars;
using Star_Wars.DTO;
using System.Collections.Generic;
using System.Linq;
namespace StarWarsUnitTest
{
    public class Tests
    {
        [Test]
        public void CalculateResupplyFreq()
        {
            StarShipService sv = new StarShipService();
            sv.Distance = 1000000;
            long resupply = (sv.Distance / (12 * 30 * 24 * 75));
            
            List<StarshipDTO> list = new List<StarshipDTO>();
            list.Add(new StarshipDTO()
            {
                Consumables = "12 months",
                Manufacturer = "Turkish Army",
                Model = "KA-FA 1500",
                MGLT = "75",
                Name = "ATAKAN"
            });
            sv.AddStarShipList(sv.Map.Map<List<StarshipDTO>, List<Starship>>(list));
            Assert.AreEqual(resupply,sv.CalculateReSupplyFrequence().First().ResupplyFrequence);
        }
        [Test]
        public void GetResponseApi()
        {
            RequestBase<ResponseDTO> req=new RequestBase<ResponseDTO>();
            var list = req.CallApi("https://swapi.co/api/starships/?page=1");
            Assert.IsTrue(list.Count>0);
        }
    }
}