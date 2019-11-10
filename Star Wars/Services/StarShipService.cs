using Star_Wars.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Star_Wars.Services;
using System.Threading.Tasks;

namespace Star_Wars
{
    public class StarShipService : IService
    {
        string _baseUrl => "https://swapi.co/api/starships/?page=1";
        public long Distance = -1;
        List<Starship> _starshipList { get; set; }
        readonly RequestBase<ResponseDTO> _requestBase;
        MapperConfiguration _config;
        public readonly IMapper Map;

        public StarShipService()
        {
            _config = InitConfig();
            Map = _config.CreateMapper();
            _requestBase = Bootstrap.container.GetInstance<RequestBase<ResponseDTO>>();
            _starshipList = new List<Starship>();
        }

        private MapperConfiguration InitConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StarshipDTO, Starship>()
                .ForMember(dest => dest.Consumables, act => act.MapFrom(src => Helper.Helper.ConvertHours(src.Consumables)))
                    .ForMember(dest => dest.MGLT, act => act.MapFrom(src => Helper.Helper.ConvertToInt(src.MGLT)));

                cfg.CreateMap<Starship, StarshipWithResupplyFrequenceDTO>()
                .ForMember(dest => dest.MGLT, act => act.MapFrom(src => src.MGLT == -1 ? "unknown" : src.MGLT.ToString())).
                ForMember(dest => dest.ResupplyFrequence, act => act.MapFrom(src => Helper.Helper.FindFreq(src.MGLT, src.Consumables, Distance)));
            });
        }
        /// <summary>
        /// Gets starships data from api
        /// </summary>
        public void PullStarShips()
        {
            string nextUrl = _baseUrl;
            do
            {
                var responseDTO = _requestBase.CallApi(nextUrl);
                nextUrl = responseDTO.NextUrl;
                AddStarShipList(Map.Map<List<StarshipDTO>, List<Starship>>(responseDTO.StarshipDTOList));
            }
            while (nextUrl != null);
        }

        public void AddStarShipList(List<Starship> list)
        {
            _starshipList.AddRange(list);
        }
        /// <summary>
        /// Return Starship,if service already has data return data without call api. 
        /// </summary>
        /// <returns></returns>
        public List<Starship> GetStarships()
        {
            if (_starshipList.Count == 0)
                PullStarShips();
            return _starshipList;
        }

        /// <summary>
        /// Calculate resupply frequence of  starships data with given mglt distance value. 
        /// </summary>
        /// <returns></returns>
        public List<StarshipWithResupplyFrequenceDTO> CalculateReSupplyFrequence()
        {
            return Map.Map<List<Starship>, List<StarshipWithResupplyFrequenceDTO>>(_starshipList);
        }
        public int GetCount()
        {
            return _starshipList.Count;
        }
    }
}
