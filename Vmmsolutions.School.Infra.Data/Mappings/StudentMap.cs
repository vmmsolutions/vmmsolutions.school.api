using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Students");

            builder.Property(p => p.FirstName).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.LastName).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.PersonalDocument).HasColumnType("varchar(30)").IsRequired().HasMaxLength(30);
            builder.Property(p => p.Email).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.Birthday).IsRequired();

            builder.Property(p => p.CreatedBy).IsRequired().HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasMany(p => p.Activities).WithOne(p => p.Student).HasForeignKey(fk => fk.StudentId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
