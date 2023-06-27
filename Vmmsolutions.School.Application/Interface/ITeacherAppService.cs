using Vmmsolutions.School.Application.Dto.Teachers;

namespace Vmmsolutions.School.Application.Interface
{
    public interface ITeacherAppService
    {
        TeacherDto GetById(Guid id);
        IEnumerable<TeacherDto> GetAll(Guid id);
        TeacherDto Insert(TeacherPostDto obj);
        void Update(Guid id, TeacherPatchDto obj);
        void Delete(Guid id);
    }
}
