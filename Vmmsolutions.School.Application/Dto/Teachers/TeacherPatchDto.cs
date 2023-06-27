namespace Vmmsolutions.School.Application.Dto.Teachers
{
    public class TeacherPatchDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PersonalDocument { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
