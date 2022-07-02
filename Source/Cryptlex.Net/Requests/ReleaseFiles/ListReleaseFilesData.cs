using System.Text.Json.Serialization;
namespace Cryptlex.Net.ReleaseFiles
{
    public class ListReleaseFilesData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("releaseId")]
        public string? ReleaseId { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}