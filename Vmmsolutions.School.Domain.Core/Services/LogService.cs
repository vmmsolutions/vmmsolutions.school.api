using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class LogService : Service<Log>, ILogService
    {
        //private readonly ILogRepository _logRepository;

        public LogService(IUnitOfWork context, ILogRepository _logRepository) : base(context, _logRepository)
        {
            Validator = new LogValidator();
        }
    }
}