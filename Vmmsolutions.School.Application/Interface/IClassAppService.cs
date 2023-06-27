using Vmmsolutions.School.Application.Dto.Classes;

namespace Vmmsolutions.School.Application.Interface
{
    public  interface IClassAppService
    {
        ClassDto GetById(Guid id);
        IEnumerable<ClassDto> GetAll(Guid id);
        ClassDto Insert(ClassPostDto obj);
        void Update(Guid id, ClassPatchDto obj);
        void Delete(Guid id);
    }
}
