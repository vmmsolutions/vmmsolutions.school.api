using Dapper.Contrib.Extensions;
using Vmmsolutions.School.Domain.Base;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Student : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalDocument { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Guid SchoolId { get; set; }

        [Write(false)]
        public virtual School School { get; set; }

        [Write(false)]
        public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

        [Write(false)]
        public virtual ICollection<ClassStudent> ClassStudents { get; set; } = new List<ClassStudent>();
    }
}
