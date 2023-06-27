namespace Vmmsolutions.School.Domain.Entities
{
    public class ClassTeacher
    {
        public Guid ClassId { get; set; }
        public virtual Classes Classes { get; set; }

        public virtual Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
