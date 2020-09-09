using AutoMapper;
using Star_Wars.DTO;

namespace Star_Wars
{
    public class MappingService : IMap
    {
        readonly IMapper _map;
        public MappingService()
        {
            _map = InitConfig().CreateMapper();
        }
        private MapperConfiguration InitConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StarshipDTO, Starship>()
                .ForMember(dest => dest.Consumables, act => act.MapFrom(src => Helper.Helper.ConvertHours(src.Consumables)))
                    .ForMember(dest => dest.MGLT, act => act.MapFrom(src => Helper.Helper.ConvertToInt(src.MGLT)));
            });
        }
        public TDestionation DoMap<TSource, TDestionation>(TSource source)
        {
            return _map.Map<TSource, TDestionation>(source);
        }
    }
}