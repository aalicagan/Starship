using Star_Wars.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Star_Wars
{
    public interface IClientService
    {
        public void Execute(long distance);
        public Task<int> CalculateReSupplyFrequence(List<Starship> starships);
        public int GetCount();
    }
}
