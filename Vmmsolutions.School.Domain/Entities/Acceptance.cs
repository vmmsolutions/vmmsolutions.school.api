using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Entities.Enums;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Acceptance : Entity
    {
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Agreed { get; set; }
        public AcceptanceEnum Type { get; set; }
    }
}
