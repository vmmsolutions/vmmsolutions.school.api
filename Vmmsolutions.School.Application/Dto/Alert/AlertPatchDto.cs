namespace Vmmsolutions.School.Application.Dto.Alert
{
    public class AlertPatchDto
    {
        public string? Name { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
