using System.Text.Json.Serialization;
namespace Cryptlex.Net.Roles
{
    public class UpdateRoleData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
		[JsonPropertyName("claims")]
        public List<string>? Claims { get; set; }
    }
}