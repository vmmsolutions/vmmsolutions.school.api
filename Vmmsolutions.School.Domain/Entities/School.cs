using Dapper.Contrib.Extensions;
using Vmmsolutions.School.Domain.Base;

namespace Vmmsolutions.School.Domain.Entities
{
    public class School : Entity
    {
        public string? Name { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        [Write(false)]
        public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

        [Write(false)]
        public virtual ICollection<Classes> Classes { get; set; } = new List<Classes>();

        [Write(false)]
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

        [Write(false)]
        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

        [Write(false)]
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        [Write(false)]
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
