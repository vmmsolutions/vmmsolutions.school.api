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
    internal class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Employees");

            builder.Property(p => p.FirstName).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.LastName).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
            builder.Property(p => p.Email).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);

            builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.UpdatedBy).IsRequired(false).HasColumnType("varchar(400)").HasMaxLength(400);
            builder.Property(p => p.UpdatedOn).IsRequired(false);
            builder.Property(p => p.IsActive).IsRequired();

        }
    }
}
