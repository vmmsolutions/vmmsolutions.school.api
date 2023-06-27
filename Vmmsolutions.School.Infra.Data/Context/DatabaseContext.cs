using Microsoft.EntityFrameworkCore;
using Vmmsolutions.School.Infra.Data.Mappings;

namespace Vmmsolutions.School.Infra.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcceptanceMap());
            modelBuilder.ApplyConfiguration(new ActivityMap());
            modelBuilder.ApplyConfiguration(new AlertMap());
            modelBuilder.ApplyConfiguration(new AttachmentMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new ClassStudentMap());
            modelBuilder.ApplyConfiguration(new ClassTeacherMap());
            modelBuilder.ApplyConfiguration(new EventMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new SchoolMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
        }
    }
}
