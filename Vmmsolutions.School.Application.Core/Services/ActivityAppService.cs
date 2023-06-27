using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Activities;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class ActivityAppService : AppService, IActivityAppService
    {
        private readonly IActivityRepository _ActivitiesRepository;
        private readonly IActivityService _ActivitiesServices;

        public ActivityAppService(IUnitOfWork uoW, IMapper mapper, IActivityRepository ActivitiesRepository, IActivityService ActivitiesServices) : base(uoW, mapper)
        {
            this._ActivitiesRepository = ActivitiesRepository;
            this._ActivitiesServices = ActivitiesServices;
        }

        public ActivityDto GetById(Guid id)
        {
            return Mapper.Map<ActivityDto>(_ActivitiesServices.GetById(id));
        }

        public IEnumerable<ActivityDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<ActivityDto>>(_ActivitiesRepository.GetAll());
        }

        public ActivityDto Insert(ActivityPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Activity entity = _ActivitiesServices.Insert(Mapper.Map<Activity>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<ActivityDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, ActivityPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Activity entity = _ActivitiesServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _ActivitiesServices.Update(entity);

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
                Activity entity = _ActivitiesRepository.GetById(id);
                _ActivitiesServices.Delete(Mapper.Map<Activity>(entity));
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