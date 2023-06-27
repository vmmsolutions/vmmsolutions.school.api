using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Acceptances;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Entities.Enums;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class AcceptanceAppService : AppService, IAcceptanceAppService
    {
        private readonly IAcceptanceRepository _AcceptanceRepository;
        private readonly IAcceptanceService _AcceptanceServices;

        public AcceptanceAppService(IUnitOfWork uoW, IMapper mapper, IAcceptanceRepository AcceptanceRepository, IAcceptanceService AcceptanceServices) : base(uoW, mapper)
        {
            this._AcceptanceRepository = AcceptanceRepository;
            this._AcceptanceServices = AcceptanceServices;
        }

        public AcceptanceDto GetById(Guid id)
        {
            return Mapper.Map<AcceptanceDto>(_AcceptanceServices.GetById(id));
        }

        public IEnumerable<AcceptanceDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<AcceptanceDto>>(_AcceptanceRepository.GetAll());
        }

        public AcceptanceDto Insert(AcceptancePostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Acceptance entity = _AcceptanceServices.Insert(Mapper.Map<Acceptance>(obj));
                entity.Agreed = true;
                UoW.Commit();

                return Mapper.Map<AcceptanceDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, AcceptancePatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Acceptance entity = _AcceptanceServices.GetById(id);
                entity.Agreed = obj.Agreed;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Type = Mapper.Map<AcceptanceEnum>(obj.Type);

                _AcceptanceServices.Update(entity);

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
                Acceptance entity = _AcceptanceRepository.GetById(id);
                _AcceptanceServices.Delete(Mapper.Map<Acceptance>(entity));
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