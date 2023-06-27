using Vmmsolutions.School.Application.Dto.Base;

namespace Vmmsolutions.School.Application.Dto.Attachments
{
    public class AttachmentDto : EntityDto
    {
        public string? Title { get; set; }
        public string? ContentType { get; set; }
        public string? BlobUrl { get; set; }
        public int? Size { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
