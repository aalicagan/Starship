using SimpleInjector;
using Star_Wars.DTO;
using Star_Wars.Helper;
using Star_Wars.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars
{
    public class Bootstrap
    {
        public static Container container;
        public static void Start()
        {
            container = new Container();
            container.Register<IRequestBase<ResponseDTO>, RequestBase<ResponseDTO>>(Lifestyle.Singleton);
            container.Register<IService, StarShipService>(Lifestyle.Singleton);
        }
    }
}
