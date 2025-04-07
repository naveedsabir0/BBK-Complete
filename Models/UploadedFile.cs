namespace MovieDatabaseBlazorServerApp.Models
{
    public class UploadedFile
    {
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string Name { get; set; }
        public string ContentType { get; set; }
        public DateTime ModifiedOn { get; set; }

        public string Extension { get => Path.GetExtension(this.Name); }

        public UploadedFile()
        {
            this.ModifiedOn = DateTime.Now;
        }
    }
}
