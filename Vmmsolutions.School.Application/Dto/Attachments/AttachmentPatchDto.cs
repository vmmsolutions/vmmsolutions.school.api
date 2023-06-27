namespace Vmmsolutions.School.Application.Dto.Attachments
{
    public class AttachmentPatchDto
    {
        public string? Title { get; set; }
        public string? ContentType { get; set; }
        public string? BlobUrl { get; set; }
        public int? Size { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
