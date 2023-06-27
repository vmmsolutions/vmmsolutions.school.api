using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Students;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class StudentAppService : AppService, IStudentAppService
    {
        private readonly IStudentRepository _StudentsRepository;
        private readonly IStudentService _StudentsServices;

        public StudentAppService(IUnitOfWork uoW, IMapper mapper, IStudentRepository StudentsRepository, IStudentService StudentsServices) : base(uoW, mapper)
        {
            this._StudentsRepository = StudentsRepository;
            this._StudentsServices = StudentsServices;
        }

        public StudentDto GetById(Guid id)
        {
            return Mapper.Map<StudentDto>(_StudentsServices.GetById(id));
        }

        public IEnumerable<StudentDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<StudentDto>>(_StudentsRepository.GetAll());
        }

        public StudentDto Insert(StudentPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Student entity = _StudentsServices.Insert(Mapper.Map<Student>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<StudentDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, StudentPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Student entity = _StudentsServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.FirstName = obj.FirstName;
                entity.LastName = obj.LastName;
                entity.Email = obj.Email;
                entity.PersonalDocument = obj.PersonalDocument;

                _StudentsServices.Update(entity);

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
                Student entity = _StudentsRepository.GetById(id);
                _StudentsServices.Delete(Mapper.Map<Student>(entity));
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