using Vmmsolutions.School.Application.Dto.Base;

namespace Vmmsolutions.School.Application.Dto.Acceptances
{
    public class AcceptanceDto : EntityDto
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Agreed { get; set; }
        public AcceptanceEnumDto Type { get; set; }
    }
}
