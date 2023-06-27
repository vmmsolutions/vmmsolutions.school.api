using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class ClassStudentMap : IEntityTypeConfiguration<ClassStudent>
    {
        public void Configure(EntityTypeBuilder<ClassStudent> builder)
        {
            builder.HasKey(t => new { t.ClassId, t.StudentId });
            builder.ToTable("ClassesStudents");

            builder.HasOne(p => p.Class).WithMany(p => p.ClassStudents).HasForeignKey(fk => fk.ClassId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Student).WithMany(p => p.ClassStudents).HasForeignKey(fk => fk.StudentId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}