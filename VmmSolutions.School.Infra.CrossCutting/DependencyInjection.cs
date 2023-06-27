using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using Vmmsolutions.School.Application.AutoMapper;
using Vmmsolutions.School.Application.Core.Services;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Core.Services;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;
using Vmmsolutions.School.Infra.Data.Context;
using Vmmsolutions.School.Infra.Data.Repositories;
using Vmmsolutions.School.Infra.Data.UoW;

namespace VmmSolutions.School.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Scoped service, a single instance is created per request and the same instance is shared across the request. 
        /// Transient service always returns a new instance even though it’s the same request.
        /// Singleton Only one service object or instance was developed throughout the lifetime,Wherever the service is needed, the same object or instance is frequently utilized.
        /// </summary>
        /// <param name="services">IServiceCollection services</param>
        /// <param name="connectionString">string connectionString</param>
        /// <returns></returns>
        public static IServiceCollection AddCrossCutting(this IServiceCollection services)
        {
            // Database configuration
            services.AddDatabaseConfiguration();

            // Services and Repositories
            services.AddServices();

            // Auto Mapper Configurations
            services.AddMapper();

            return services;
        }

        private static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DatabaseContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDbConnection>(db => new SqlConnection(services.getConnectionString()));
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(services.getConnectionString()), ServiceLifetime.Scoped);

            return services;
        }

        private static string getConnectionString(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            string connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            return connectionString;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfig = AutoMapperConfig.RegisterMappings();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAcceptanceAppService, AcceptanceAppService>();
            services.AddScoped<IAcceptanceService, AcceptanceService>();
            services.AddScoped<IAcceptanceRepository, AcceptanceRepository>();

            services.AddScoped<IActivityAppService, ActivityAppService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            services.AddScoped<IAlertAppService, AlertAppService>();
            services.AddScoped<IAlertService, AlertService>();
            services.AddScoped<IAlertRepository, AlertRepository>();

            services.AddScoped<IAttachmentAppService, AttachmentAppService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();

            services.AddScoped<IClassAppService, ClassAppService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IClassRepository, ClassRepository>();

            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEventAppService, EventAppService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddScoped<ILogAppService, LogAppService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<ISchoolAppService, SchoolAppService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ITeacherAppService, TeacherAppService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            return services;
        }
    }
}
