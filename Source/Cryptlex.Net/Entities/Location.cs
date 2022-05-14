namespace Cryptlex.Net.Entities
{
    public class Location
    {
        public string ipAddress { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string regionCode { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string timeZone { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
