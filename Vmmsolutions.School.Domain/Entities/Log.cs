using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Entities.Enums;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Log : Entity
    {
        public string? Controller { get; set; }
        public string? Method { get; set; }
        public string? Message { get; set; }
        public string? BlobUri { get; set; }
        public LogEnum Status { get; set; }

        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? ExternalId { get; set; }
    }
}
