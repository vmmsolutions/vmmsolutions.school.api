using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Schools;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class SchoolAppService : AppService, ISchoolAppService
    {
        private readonly ISchoolRepository _SchoolsRepository;
        private readonly ISchoolService _SchoolsServices;

        public SchoolAppService(IUnitOfWork uoW, IMapper mapper, ISchoolRepository SchoolsRepository, ISchoolService SchoolsServices) : base(uoW, mapper)
        {
            this._SchoolsRepository = SchoolsRepository;
            this._SchoolsServices = SchoolsServices;
        }

        public SchoolDto GetById(Guid id)
        {
            return Mapper.Map<SchoolDto>(_SchoolsServices.GetById(id));
        }

        public IEnumerable<SchoolDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<SchoolDto>>(_SchoolsRepository.GetAll());
        }

        public SchoolDto Insert(SchoolPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                var entity = _SchoolsServices.Insert(Mapper.Map<Domain.Entities.School>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<SchoolDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, SchoolPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Domain.Entities.School entity = _SchoolsServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _SchoolsServices.Update(entity);

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
                Domain.Entities.School entity = _SchoolsRepository.GetById(id);
                _SchoolsServices.Delete(Mapper.Map<Domain.Entities.School>(entity));
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
