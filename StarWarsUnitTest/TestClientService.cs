using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Star_Wars;
using Star_Wars.DTO;
using System;
using System.Collections.Generic;
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
        [ExpectedException(typeof(ArgumentException),
    "Distance must be greater than zero")]
        public void TestExecuteWrongDistance()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            service.Execute(-1000);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException),
    "Distance must be greater than zero")]
        public void TestExecuteWrongDistance2()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            service.Execute(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), "No Data Found")]
        public async System.Threading.Tasks.Task TestGetCountAsync()
        {
            Bootstrap.Start();
            IClientService service = Bootstrap.container.GetInstance<IClientService>();
            await service.GetCount();
        }

        [Test]
        public async System.Threading.Tasks.Task TestCalculateReSupplyFrequenceAsync()
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
