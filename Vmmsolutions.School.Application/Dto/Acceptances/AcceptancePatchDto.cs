namespace Vmmsolutions.School.Application.Dto.Acceptances
{
    public class AcceptancePatchDto
    {
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Agreed { get; set; }
        public AcceptanceEnumDto Type { get; set; }
    }
}
