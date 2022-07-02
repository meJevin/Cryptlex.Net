using System.Text.Json.Serialization;
namespace Cryptlex.Net.Roles
{
    public class CreateRoleData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
		[JsonPropertyName("claims")]
        public List<string> Claims { get; set; }

        public CreateRoleData(string name, List<string> claims)
        {
            this.Name = name;
            this.Claims = claims;
        }
    }
}