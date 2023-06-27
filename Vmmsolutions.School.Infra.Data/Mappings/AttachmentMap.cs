using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class AttachmentMap : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Attachments");

            builder.Property(p => p.Title).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(p => p.BlobUrl).IsRequired().HasColumnType("varchar(2000)").HasMaxLength(2000);
            builder.Property(p => p.ContentType).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.Size).IsRequired(false);

            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
        }
    }
}