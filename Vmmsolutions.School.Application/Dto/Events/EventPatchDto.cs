namespace Vmmsolutions.School.Application.Dto.Events
{
    public class EventPatchDto
    {
        public string? Name { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
