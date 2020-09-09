using SimpleInjector;
using Star_Wars.Client;
using Star_Wars.DTO;
using Star_Wars.Helper;
using Star_Wars.Services;

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
            container.Register<IMap, MappingService>(Lifestyle.Singleton);
            container.Register<IClientService, ClientService>(Lifestyle.Singleton);
        }
    }
}
