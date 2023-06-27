using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class SchoolService : Service<Entities.School>, ISchoolService
    {
        //private readonly ISchoolRepository _schoolRepository;

        public SchoolService(IUnitOfWork context, ISchoolRepository _schoolRepository) : base(context, _schoolRepository)
        {
            Validator = new SchoolValidator();
        }
    }
}