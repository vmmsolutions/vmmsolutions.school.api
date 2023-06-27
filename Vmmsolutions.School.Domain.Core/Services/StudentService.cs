using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        //private readonly IStudentRepository _studentRepository;

        public StudentService(IUnitOfWork context, IStudentRepository _studentRepository) : base(context, _studentRepository)
        {
            Validator = new StudentValidator();
        }
    }
}