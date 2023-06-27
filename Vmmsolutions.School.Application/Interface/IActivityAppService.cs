using Vmmsolutions.School.Application.Dto.Activities;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IActivityAppService
    {
        ActivityDto GetById(Guid id);
        IEnumerable<ActivityDto> GetAll(Guid id);
        ActivityDto Insert(ActivityPostDto obj);
        void Update(Guid id, ActivityPatchDto obj);
        void Delete(Guid id);
    }
}
