using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class AcceptanceService : Service<Acceptance>, IAcceptanceService
    {
        //private readonly IAcceptanceRepository _acceptanceRepository;

        public AcceptanceService(IUnitOfWork context, IAcceptanceRepository _acceptanceRepository) : base(context, _acceptanceRepository)
        {
            Validator = new AcceptanceValidator();
        }
    }
}
