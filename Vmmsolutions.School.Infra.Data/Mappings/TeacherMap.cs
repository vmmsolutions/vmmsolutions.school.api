using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Teachers");

            builder.Property(p => p.FirstName).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.LastName).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.Email).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);

            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasMany(p => p.Activities).WithOne(p => p.Teacher).HasForeignKey(fk => fk.TeacherId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Employee).WithOne(p => p.Teacher).HasForeignKey<Teacher>(p => p.EmployeeId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
