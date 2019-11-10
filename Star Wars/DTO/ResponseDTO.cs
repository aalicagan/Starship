using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars.DTO
{
    public class ResponseDTO
    {
        [JsonProperty(PropertyName = "count")]
        public long Count { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string NextUrl { get; set; }

        [JsonProperty(PropertyName = "previous")]
        public string PreviousUrl { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<StarshipDTO> StarshipDTOList { get; set; }
    }
}
