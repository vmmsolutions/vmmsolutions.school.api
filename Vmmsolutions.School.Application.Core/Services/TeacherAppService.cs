using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Teachers;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{

    public class TeacherAppService : AppService, ITeacherAppService
    {
        private readonly ITeacherRepository _TeachersRepository;
        private readonly ITeacherService _TeachersServices;

        public TeacherAppService(IUnitOfWork uoW, IMapper mapper, ITeacherRepository TeachersRepository, ITeacherService TeachersServices) : base(uoW, mapper)
        {
            this._TeachersRepository = TeachersRepository;
            this._TeachersServices = TeachersServices;
        }

        public TeacherDto GetById(Guid id)
        {
            return Mapper.Map<TeacherDto>(_TeachersServices.GetById(id));
        }

        public IEnumerable<TeacherDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<TeacherDto>>(_TeachersRepository.GetAll());
        }

        public TeacherDto Insert(TeacherPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Teacher entity = _TeachersServices.Insert(Mapper.Map<Teacher>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<TeacherDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, TeacherPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Teacher entity = _TeachersServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.FirstName = obj.FirstName;
                entity.LastName = obj.LastName;
                entity.Email = obj.Email;

                _TeachersServices.Update(entity);

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
                Teacher entity = _TeachersRepository.GetById(id);
                _TeachersServices.Delete(Mapper.Map<Teacher>(entity));
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