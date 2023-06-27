using Vmmsolutions.School.Application.Dto.Employees;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IEmployeeAppService
    {
        EmployeeDto GetById(Guid id);
        IEnumerable<EmployeeDto> GetAll(Guid id);
        EmployeeDto Insert(EmployeePostDto obj);
        void Update(Guid id, EmployeePatchDto obj);
        void Delete(Guid id);
    }
}
