using Vmmsolutions.School.Domain.Base;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Attachment : Entity
    {
        public string? Title { get; set; }
        public string? ContentType { get; set; }
        public required string BlobUrl { get; set; }
        public int? Size { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
