using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Star_Wars;
using Star_Wars.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace StarWarsUnitTest
{
    class TestStarshipService
    {
        [Test]
        public void TestGenerateStarshipService()
        {
            Bootstrap.Start();
            IService service = Bootstrap.container.GetInstance<IService>();
            Assert.IsTrue(service != null);
        }
        [Test]
        public void TestGetDataAsync()
        {
            Bootstrap.Start();
            IService service = Bootstrap.container.GetInstance<IService>();
            try
            {
                var result = service.GetDataAsync("https://swapi.dev/api/starships/?page=1");
                Assert.IsTrue(result != null);
            }
            catch (System.Exception)
            {

                Assert.IsTrue(false);
            }
        }
        [Test]
        [ExpectedException(typeof(ArgumentException),
    "xxx return unsuccessfull")]
        public void TestGetDataAsyncWrong()
        {
            Bootstrap.Start();
            IService service = Bootstrap.container.GetInstance<IService>();
            var result = service.GetDataAsync("xxx");
        }
    }
}
