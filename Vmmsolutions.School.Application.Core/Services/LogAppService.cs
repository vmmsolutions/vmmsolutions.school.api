using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Logs;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class LogAppService : AppService, ILogAppService
    {
        private readonly ILogRepository _LogRepository;
        private readonly ILogService _LogServices;

        public LogAppService(IUnitOfWork uoW, IMapper mapper, ILogRepository LogRepository, ILogService LogServices) : base(uoW, mapper)
        {
            this._LogRepository = LogRepository;
            this._LogServices = LogServices;
        }

        public LogDto GetById(Guid id)
        {
            return Mapper.Map<LogDto>(_LogServices.GetById(id));
        }

        public IEnumerable<LogDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<LogDto>>(_LogRepository.GetAll());
        }

        public LogDto Insert(LogPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Log entity = _LogServices.Insert(Mapper.Map<Log>(obj));
                UoW.Commit();

                return Mapper.Map<LogDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, LogPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Log entity = _LogServices.GetById(id);
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Status = obj.Status;
                entity.Controller = obj.Controller;
                entity.Method = obj.Method;
                entity.Message = obj.Message;
                entity.ExternalId = obj.ExternalId;

                _LogServices.Update(entity);

                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                UoW.BeginTransaction();
                Log entity = _LogRepository.GetById(id);
                _LogServices.Delete(Mapper.Map<Log>(entity));
                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }
    }
}