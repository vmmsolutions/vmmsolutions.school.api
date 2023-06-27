using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class ClassTeacherMap : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> builder)
        {
            builder.HasKey(t => new { t.ClassId, t.TeacherId });
            builder.ToTable("ClassesTeachers");

            builder.HasOne(p => p.Classes).WithMany(p => p.ClassTeachers).HasForeignKey(fk => fk.ClassId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Teacher).WithMany(p => p.ClassTeachers).HasForeignKey(fk => fk.TeacherId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}