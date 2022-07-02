using System.Text.Json.Serialization;
namespace Cryptlex.Net.Tags
{
    public class UpdateTagData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}