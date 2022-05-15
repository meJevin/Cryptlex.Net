namespace Cryptlex.Net.Tags
{
    public class CreateTagData
    {
        public string name { get; set; }
        public string description { get; set; }

        public CreateTagData(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
