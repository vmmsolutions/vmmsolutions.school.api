namespace Vmmsolutions.School.Application.Dto.Attachments
{
    public class AttachmentPostDto
    {
        public string? Title { get; set; }
        public string? ContentType { get; set; }
        public string? BlobUrl { get; set; }
        public int? Size { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
