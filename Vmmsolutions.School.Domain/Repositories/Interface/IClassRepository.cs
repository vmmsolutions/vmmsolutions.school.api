using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;

namespace Vmmsolutions.School.Domain.Repositories.Interface
{
    public interface IClassRepository : IRepository<Classes>
    {
        Classes GetByCreatedBy(string createdBy, int type);
        IEnumerable<Classes> GetAll(string createdBy, int? type, string sort, int page, int per_page, out int total);
    }
}
