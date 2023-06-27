using Dapper.Contrib.Extensions;
using Vmmsolutions.School.Domain.Base;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Event : Entity
    {
        public string? Name { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Guid SchoolId { get; set; }

        [Write(false)]
        public virtual School School { get; set; }
    }
}
