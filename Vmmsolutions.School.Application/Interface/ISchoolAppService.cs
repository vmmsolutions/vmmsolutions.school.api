using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vmmsolutions.School.Application.Dto.Schools;

namespace Vmmsolutions.School.Application.Interface
{
    public interface ISchoolAppService
    {
        SchoolDto GetById(Guid id);
        IEnumerable<SchoolDto> GetAll(Guid id);
        SchoolDto Insert(SchoolPostDto obj);
        void Update(Guid id, SchoolPatchDto obj);
        void Delete(Guid id);
    }
}
