using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class AcceptanceMap : IEntityTypeConfiguration<Acceptance>
    {
        public void Configure(EntityTypeBuilder<Acceptance> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Acceptances");

            builder.Property(p => p.Type).IsRequired();
            builder.Property(p => p.Agreed).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
        }
    }
}