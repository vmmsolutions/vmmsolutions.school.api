using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Infra.Data.Base;

namespace Vmmsolutions.School.Infra.Data.Repositories
{
    public class AcceptanceRepository : Repository<Acceptance>, IAcceptanceRepository
    {
        public AcceptanceRepository(IUnitOfWork context) : base(context)
        {
        }
    }
}