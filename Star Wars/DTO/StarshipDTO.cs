using Newtonsoft.Json;

namespace Star_Wars.DTO
{
    public class StarshipDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "consumables")]
        public string Consumables { get; set; }

        [JsonProperty(PropertyName = "MGLT")]
        public string MGLT { get; set; }
    }
}
