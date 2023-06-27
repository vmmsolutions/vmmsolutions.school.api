using Vmmsolutions.School.Domain.Entities.Enums;

namespace Vmmsolutions.School.Application.Dto.Employees
{
    public class EmployeePostDto
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
    }
}
