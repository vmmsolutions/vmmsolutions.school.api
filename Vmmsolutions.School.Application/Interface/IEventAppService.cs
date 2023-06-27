using Vmmsolutions.School.Application.Dto.Events;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IEventAppService
    {
        EventDto GetById(Guid id);
        IEnumerable<EventDto> GetAll(Guid id);
        EventDto Insert(EventPostDto obj);
        void Update(Guid id, EventPatchDto obj);
        void Delete(Guid id);
    }
}
