using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CowApi.Models
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public int Latitude { get; set; }
        [JsonPropertyName("long")]
        public int Longitude { get; set; }
    }
}
