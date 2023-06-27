using Dapper.Contrib.Extensions;
using Vmmsolutions.School.Domain.Base;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Classes : Entity
    {
        public string? Name { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
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

        [Write(false)]
        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; } = new List<ClassTeacher>();
    }
}
