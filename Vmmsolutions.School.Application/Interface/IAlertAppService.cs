using Vmmsolutions.School.Application.Dto.Alert;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IAlertAppService
    {
        AlertDto GetById(Guid id);
        IEnumerable<AlertDto> GetAll(Guid id);
        AlertDto Insert(AlertPostDto obj);
        void Update(Guid id, AlertPatchDto obj);
        void Delete(Guid id);
    }
}
