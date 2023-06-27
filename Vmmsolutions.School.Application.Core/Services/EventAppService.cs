using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Events;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class EventAppService : AppService, IEventAppService
    {
        private readonly IEventRepository _EventsRepository;
        private readonly IEventService _EventsServices;

        public EventAppService(IUnitOfWork uoW, IMapper mapper, IEventRepository EventsRepository, IEventService EventsServices) : base(uoW, mapper)
        {
            this._EventsRepository = EventsRepository;
            this._EventsServices = EventsServices;
        }

        public EventDto GetById(Guid id)
        {
            return Mapper.Map<EventDto>(_EventsServices.GetById(id));
        }

        public IEnumerable<EventDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<EventDto>>(_EventsRepository.GetAll());
        }

        public EventDto Insert(EventPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Event entity = _EventsServices.Insert(Mapper.Map<Event>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<EventDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, EventPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Event entity = _EventsServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _EventsServices.Update(entity);

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
                Event entity = _EventsRepository.GetById(id);
                _EventsServices.Delete(Mapper.Map<Event>(entity));
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