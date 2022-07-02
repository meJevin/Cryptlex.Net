using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class AccountCheckSSOEnabledData
    {
		[JsonPropertyName("comapnyId")]
        public string ComapnyId { get; set; }

        public AccountCheckSSOEnabledData(string comapnyId)
        {
            this.ComapnyId = comapnyId;
        }
    }
}