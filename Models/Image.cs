namespace BRTS.Web.Models
{
    public class Image
    {
        public byte[]? ImageData { get; set; }

        public int ImageId { get; set; }
        public string? ImageName { get; set; }
        public string? ImageContentType { get; set; }
    }
}
