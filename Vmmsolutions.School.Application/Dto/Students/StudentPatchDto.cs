namespace Vmmsolutions.School.Application.Dto.Students
{
    public class StudentPatchDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalDocument { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
