using System.Text.Json.Serialization;
namespace Cryptlex.Net.Tags
{
    public class CreateTagData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("description")]
        public string Description { get; set; }

        public CreateTagData(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}