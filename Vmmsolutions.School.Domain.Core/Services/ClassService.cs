using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class ClassService : Service<Classes>, IClassService
    {
        //private readonly IClassRepository _classRepository;

        public ClassService(IUnitOfWork context, IClassRepository _classRepository) : base(context, _classRepository)
        {
            Validator = new ClassValidator();
        }
    }
}