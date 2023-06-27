using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Infra.Data.Base;

namespace Vmmsolutions.School.Infra.Data.Repositories
{
    public class SchoolRepository : Repository<Domain.Entities.School>, ISchoolRepository
    {
        public SchoolRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}