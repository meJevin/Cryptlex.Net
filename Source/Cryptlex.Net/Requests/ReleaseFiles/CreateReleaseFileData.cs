namespace Cryptlex.Net.ReleaseFiles
{
    public class CreateReleaseFileData
    {
        public string name { get; set; }
        public string url { get; set; }
        public int size { get; set; }
        public string checksum { get; set; }
        public bool secured { get; set; }
        public string releaseId { get; set; }

        public CreateReleaseFileData(
            string name, string url, int size,
            string checksum, bool secured, string releaseId)
        {
            this.name = name;
            this.url = url;
            this.size = size;
            this.checksum = checksum;
            this.secured = secured;
            this.releaseId = releaseId;
        }
    }
}
