using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Classes;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class ClassAppService : AppService, IClassAppService
    {
        private readonly IClassRepository _classesRepository;
        private readonly IClassService _classesServices;

        public ClassAppService(IUnitOfWork uoW, IMapper mapper, IClassRepository classesRepository, IClassService classesServices) : base(uoW, mapper)
        {
            this._classesRepository = classesRepository;
            this._classesServices = classesServices;
        }

        public ClassDto GetById(Guid id)
        {
            return Mapper.Map<ClassDto>(_classesServices.GetById(id));
        }

        public IEnumerable<ClassDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<ClassDto>>(_classesRepository.GetAll());
        }

        public ClassDto Insert(ClassPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Classes entity = _classesServices.Insert(Mapper.Map<Classes>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<ClassDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, ClassPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Classes entity = _classesServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _classesServices.Update(entity);

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
                Classes entity = _classesRepository.GetById(id);
                _classesServices.Delete(Mapper.Map<Classes>(entity));
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
