using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Employees;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IEmployeeService _EmployeeServices;

        public EmployeeAppService(IUnitOfWork uoW, IMapper mapper, IEmployeeRepository EmployeeRepository, IEmployeeService EmployeeServices) : base(uoW, mapper)
        {
            this._EmployeeRepository = EmployeeRepository;
            this._EmployeeServices = EmployeeServices;
        }

        public EmployeeDto GetById(Guid id)
        {
            return Mapper.Map<EmployeeDto>(_EmployeeServices.GetById(id));
        }

        public IEnumerable<EmployeeDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<EmployeeDto>>(_EmployeeRepository.GetAll());
        }

        public EmployeeDto Insert(EmployeePostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Employee entity = _EmployeeServices.Insert(Mapper.Map<Employee>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<EmployeeDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, EmployeePatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Employee entity = _EmployeeServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Phone = obj.Phone;

                _EmployeeServices.Update(entity);

                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                UoW.BeginTransaction();
                Employee entity = _EmployeeRepository.GetById(id);
                _EmployeeServices.Delete(Mapper.Map<Employee>(entity));
                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }
    }
}