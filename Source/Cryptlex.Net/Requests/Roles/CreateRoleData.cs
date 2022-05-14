namespace Cryptlex.Net.Roles
{
    public class CreateRoleData
    {
        public string name { get; set; }
        public string? description { get; set; }
        public List<string> claims { get; set; }

        public CreateRoleData(string name, List<string> claims)
        {
            this.name = name;
            this.claims = claims;
        }
    }
}
