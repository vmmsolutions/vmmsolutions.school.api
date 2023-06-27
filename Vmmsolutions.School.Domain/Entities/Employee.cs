using Dapper.Contrib.Extensions;
using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Entities.Enums;

namespace Vmmsolutions.School.Domain.Entities
{
    public class Employee : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalDocument { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Cellphone { get; set; }
        public EmployeeEnum Type { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        [Write(false)]
        public virtual Teacher Teacher { get; set; }
    }
}
