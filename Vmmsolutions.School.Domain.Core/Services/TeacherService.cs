using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class TeacherService : Service<Teacher>, ITeacherService
    {
        //private readonly ITeacherRepository _teacherRepository;
        public TeacherService(IUnitOfWork context, ITeacherRepository _teacherRepository) : base(context, _teacherRepository)
        {
            Validator = new TeacherValidator();
        }
    }
}