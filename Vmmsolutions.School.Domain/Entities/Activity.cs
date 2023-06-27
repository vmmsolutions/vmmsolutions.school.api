using Dapper.Contrib.Extensions;
using Vmmsolutions.School.Domain.Base;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Activity : Entity
    {
        public required string Name { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Guid ClassId { get; set; }

        [Write(false)]
        public virtual Classes Class { get; set; }

        public virtual Guid StudentId { get; set; }

        [Write(false)]
        public virtual Student Student { get; set; }

        public virtual Guid TeacherId { get; set; }

        [Write(false)]
        public virtual Teacher Teacher { get; set; }
    }
}
