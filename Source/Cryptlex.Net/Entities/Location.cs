using System.Text.Json.Serialization;
namespace Cryptlex.Net.Entities
{
    public class Location
    {
		[JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }
		[JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
		[JsonPropertyName("countryName")]
        public string CountryName { get; set; }
		[JsonPropertyName("regionCode")]
        public string RegionCode { get; set; }
		[JsonPropertyName("regionName")]
        public string RegionName { get; set; }
		[JsonPropertyName("city")]
        public string City { get; set; }
		[JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }
		[JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }
		[JsonPropertyName("latitude")]
        public double Latitude { get; set; }
		[JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}