using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        //private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWork context, IEmployeeRepository _employeeRepository) : base(context, _employeeRepository)
        {
            Validator = new EmployeeValidator();
        }
    }
}