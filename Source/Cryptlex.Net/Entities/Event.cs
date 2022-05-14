using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Entities
{
    public class Event
    {
        [JsonPropertyName("event")]
        public string Type { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }

        [JsonPropertyName("triggeredAt")]
        public DateTime? TriggeredAt { get; set; }

        public T DataAs<T>()
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(Data))!;
        }
    }
}
