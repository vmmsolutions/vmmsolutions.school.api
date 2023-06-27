using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class ClassMap : IEntityTypeConfiguration<Classes>
    {
        public void Configure(EntityTypeBuilder<Classes> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Classes");

            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.Semester).IsRequired().HasColumnType("int(2)").HasMaxLength(2);
            builder.Property(p => p.Year).IsRequired().HasColumnType("varchar(3000)").HasMaxLength(3000);

            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasMany(p => p.Activities).WithOne(p => p.Class).HasForeignKey(fk => fk.ClassId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
