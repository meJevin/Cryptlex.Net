using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialPolicies
{
    public class ListTrialPoliciesData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}