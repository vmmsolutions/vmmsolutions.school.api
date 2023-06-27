using Vmmsolutions.School.Application.Dto.Logs;

namespace Vmmsolutions.School.Application.Interface
{
    public interface ILogAppService
    {
        LogDto GetById(Guid id);
        IEnumerable<LogDto> GetAll(Guid id);
        LogDto Insert(LogPostDto obj);
        void Update(Guid id, LogPatchDto obj);
        void Delete(Guid id);
    }
}
