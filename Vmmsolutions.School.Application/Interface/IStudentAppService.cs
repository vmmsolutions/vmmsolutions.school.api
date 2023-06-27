using Vmmsolutions.School.Application.Dto.Students;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IStudentAppService
    {
        StudentDto GetById(Guid id);
        IEnumerable<StudentDto> GetAll(Guid id);
        StudentDto Insert(StudentPostDto obj);
        void Update(Guid id, StudentPatchDto obj);
        void Delete(Guid id);
    }
}
