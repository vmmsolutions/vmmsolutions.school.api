using Vmmsolutions.School.Application.Dto.Base;

namespace Vmmsolutions.School.Application.Dto.Activities
{
    public class ActivityPatchDto : EntityDto
    {
        public string Name { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
