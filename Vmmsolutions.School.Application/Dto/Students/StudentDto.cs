using Vmmsolutions.School.Application.Dto.Base;

namespace Vmmsolutions.School.Application.Dto.Students
{
    public class StudentDto : EntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalDocument { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
