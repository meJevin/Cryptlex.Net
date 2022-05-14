namespace Cryptlex.Net.Roles
{
    public class UpdateRoleData
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public List<string>? claims { get; set; }
    }
}
