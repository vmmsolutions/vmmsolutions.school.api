using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Logs");

            builder.Property(p => p.Controller).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(p => p.Method).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(p => p.Message).IsRequired().HasColumnType("varchar(4000)").HasMaxLength(4000);
            builder.Property(p => p.BlobUri).IsRequired(false).HasColumnType("varchar(1000)").HasMaxLength(1000);

            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.Status).IsRequired();
        }
    }
}