using NUnit.Framework;
using Star_Wars;
using Star_Wars.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsUnitTest
{
    class TestRequestBase
    {
        [Test]
        public void TestCallApi()
        {
            RequestBase<ResponseDTO> req = new RequestBase<ResponseDTO>();
            try
            {
                var list = req.CallApiAsync("https://swapi.dev/api/starships/?page=1");
                Assert.IsTrue(list != null);
            }
            catch (System.Exception)
            {

                Assert.IsTrue(false);
            }

        }
    }
}
