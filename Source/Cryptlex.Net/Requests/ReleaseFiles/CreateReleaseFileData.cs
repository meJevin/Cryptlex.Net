using System.Text.Json.Serialization;
namespace Cryptlex.Net.ReleaseFiles
{
    public class CreateReleaseFileData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("url")]
        public string Url { get; set; }
		[JsonPropertyName("size")]
        public int Size { get; set; }
		[JsonPropertyName("checksum")]
        public string Checksum { get; set; }
		[JsonPropertyName("secured")]
        public bool Secured { get; set; }
		[JsonPropertyName("releaseId")]
        public string ReleaseId { get; set; }

        public CreateReleaseFileData(
            string name, string url, int size,
            string checksum, bool secured, string releaseId)
        {
            this.Name = name;
            this.Url = url;
            this.Size = size;
            this.Checksum = checksum;
            this.Secured = secured;
            this.ReleaseId = releaseId;
        }
    }
}