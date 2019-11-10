using Star_Wars.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars.Services
{
    public interface IService
    {
        public void PullStarShips();
        public void AddStarShipList(List<Starship> list);
        public List<Starship> GetStarships();
        public List<StarshipWithResupplyFrequenceDTO> CalculateReSupplyFrequence();
    }
}
