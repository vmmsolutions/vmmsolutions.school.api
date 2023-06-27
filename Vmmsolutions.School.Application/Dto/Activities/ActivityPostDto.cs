using Vmmsolutions.School.Application.Dto.Base;

namespace Vmmsolutions.School.Application.Dto.Activities
{
    public class ActivityPostDto : EntityDto
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
