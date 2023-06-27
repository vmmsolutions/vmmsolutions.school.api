using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Alert;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class AlertAppService : AppService, IAlertAppService
    {
        private readonly IAlertRepository _AlertsRepository;
        private readonly IAlertService _AlertsServices;

        public AlertAppService(IUnitOfWork uoW, IMapper mapper, IAlertRepository AlertsRepository, IAlertService AlertsServices) : base(uoW, mapper)
        {
            this._AlertsRepository = AlertsRepository;
            this._AlertsServices = AlertsServices;
        }

        public AlertDto GetById(Guid id)
        {
            return Mapper.Map<AlertDto>(_AlertsServices.GetById(id));
        }

        public IEnumerable<AlertDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<AlertDto>>(_AlertsRepository.GetAll());
        }

        public AlertDto Insert(AlertPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Alert entity = _AlertsServices.Insert(Mapper.Map<Alert>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<AlertDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, AlertPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Alert entity = _AlertsServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _AlertsServices.Update(entity);

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
                Alert entity = _AlertsRepository.GetById(id);
                _AlertsServices.Delete(Mapper.Map<Alert>(entity));
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