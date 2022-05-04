using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CowApi.Enums
{
    [JsonConverter(typeof( JsonStringEnumConverter ))]
    public enum CollarStatus
    {
        [JsonPropertyName("Healthy")]
        Healthy = 0,
        [JsonPropertyName("Broken")]
        Broken = 1
    }
}
