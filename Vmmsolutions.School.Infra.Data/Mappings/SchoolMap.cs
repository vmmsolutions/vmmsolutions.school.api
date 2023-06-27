using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class SchoolMap : IEntityTypeConfiguration<Domain.Entities.School>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.School> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Schools");

            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasMany(p => p.Alerts).WithOne(p => p.School).HasForeignKey(fk => fk.SchoolId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Classes).WithOne(p => p.School).HasForeignKey(fk => fk.SchoolId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Events).WithOne(p => p.School).HasForeignKey(fk => fk.SchoolId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Menus).WithOne(p => p.School).HasForeignKey(fk => fk.SchoolId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Students).WithOne(p => p.School).HasForeignKey(fk=> fk.SchoolId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Teachers).WithOne(p => p.School).HasForeignKey(fk => fk.SchoolId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}