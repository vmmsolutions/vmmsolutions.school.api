using Vmmsolutions.School.Application.Dto.Acceptances;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IAcceptanceAppService
    {
        AcceptanceDto GetById(Guid id);
        IEnumerable<AcceptanceDto> GetAll(Guid id);
        AcceptanceDto Insert(AcceptancePostDto obj);
        void Update(Guid id, AcceptancePatchDto obj);
        void Delete(Guid id);
    }
}
