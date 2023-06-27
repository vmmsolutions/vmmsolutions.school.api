using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class EventService : Service<Event>, IEventService
    {
        //private readonly IEventRepository _eventRepository;

        public EventService(IUnitOfWork context, IEventRepository _eventRepository) : base(context, _eventRepository)
        {
            Validator = new EventValidator();
        }
    }
}