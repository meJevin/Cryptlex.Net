using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class UpdateAccountStatusData
    {
		[JsonPropertyName("status")]
        public string Status { get; set; }

        public UpdateAccountStatusData(string status)
        {
            this.Status = status;
        }
    }
}