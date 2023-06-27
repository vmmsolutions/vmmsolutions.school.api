﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Infra.Data.Mappings
{
    internal class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Activities");

            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}
