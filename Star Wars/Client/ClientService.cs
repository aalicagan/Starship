using Star_Wars.DTO;
using Star_Wars.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Star_Wars.Client
{
    public class ClientService : IClientService
    {
        string BaseUrl => "https://swapi.dev/api/starships/?page=1";
        private long Distance { get; set; }
        readonly IService _service;
        readonly IMap _map;
        List<Starship> StarshipList { get; set; }

        public ClientService(IService service, IMap map)
        {
            _service = service;
            _map = map;
        }
        /// <summary>
        /// Call API to get data and find resupply count for each Starship
        /// </summary>
        /// <param name="distance"></param>
        public async void Execute(long distance)
        {
            StarshipList = new List<Starship>();
            Distance = distance;
            string nextUrl = BaseUrl;
            do
            {
                var result = await _service.GetDataAsync(nextUrl);
                var starships = _map.DoMap<List<StarshipDTO>, List<Starship>>(result.StarshipDTOList);
                nextUrl = result.NextUrl;
                CalculateReSupplyFrequence(starships);
                StarshipList.AddRange(starships);
            }
            while (nextUrl != null);
        }
        /// <summary>
        /// Get Starship count
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            if (StarshipList == null)
                throw new Exception("No Data Found");
            return StarshipList.Count;
        }

        /// <summary>
        /// Calculate and print StarShip resupply count
        /// </summary>
        /// <param name="starships"> List of Starship</param>
        /// <returns></returns>
        public async Task<int> CalculateReSupplyFrequence(List<Starship> starships)
        {

            foreach (var item in starships)
            {
                var freq = Helper.Helper.FindFreq(item.MGLT, item.Consumables, Distance);
                Console.WriteLine($@"{item.Name} Mglt: {item.MGLT} ResuppyFreq No.: {(freq == -1 ? "unkonwn" : freq.ToString())}");
            }
            return 0;
        }
    }
}
