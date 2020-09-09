using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Star_Wars;
using Star_Wars.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
namespace StarWarsUnitTest
{
    class TestClientService
    {
        [Test]
        public void TestGenerateClientService()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            Assert.IsTrue(service != null);
        }

        [Test]
        public void TestExecute()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            try
            {
                service.Execute(10000);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.IsTrue(false);
            }
        }

        [Test]
        public async Task TestExecuteWrongDistanceAsync()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            Assert.ThrowsAsync<Exception>(async () => await service.Execute(-1000));
        }

        [Test]
        public async Task TestExecuteWrongDistance2Async()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            Assert.ThrowsAsync<Exception>(async () => await service.Execute(0));
        }

        [Test]
        public async Task TestGetCountAsync()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            Assert.ThrowsAsync<Exception>(async () => await service.GetCount());
        }

        [Test]
        public async Task TestCalculateReSupplyFrequenceAsync()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            List<Starship> list = new List<Starship>();
            list.Add(new Starship()
            {
                Consumables = 12,
                Manufacturer = "XX",
                MGLT = 10,
                Model = "YY",
                Name = "AA"
            });
            Assert.AreEqual(0, await service.CalculateReSupplyFrequence(list));
        }
    }
}
