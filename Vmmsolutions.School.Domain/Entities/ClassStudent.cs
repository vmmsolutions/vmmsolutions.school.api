namespace Vmmsolutions.School.Domain.Entities
{
    public class ClassStudent
    {
        public Guid ClassId { get; set; }
        public virtual Classes Class { get; set; }

        public virtual Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
