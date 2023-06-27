using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Menus;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class MenuAppService : AppService, IMenuAppService
    {
        private readonly IMenuRepository _MenusRepository;
        private readonly IMenuService _MenusServices;

        public MenuAppService(IUnitOfWork uoW, IMapper mapper, IMenuRepository MenusRepository, IMenuService MenusServices) : base(uoW, mapper)
        {
            this._MenusRepository = MenusRepository;
            this._MenusServices = MenusServices;
        }

        public MenuDto GetById(Guid id)
        {
            return Mapper.Map<MenuDto>(_MenusServices.GetById(id));
        }

        public IEnumerable<MenuDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<MenuDto>>(_MenusRepository.GetAll());
        }

        public MenuDto Insert(MenuPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Menu entity = _MenusServices.Insert(Mapper.Map<Menu>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<MenuDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, MenuPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Menu entity = _MenusServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _MenusServices.Update(entity);

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
                Menu entity = _MenusRepository.GetById(id);
                _MenusServices.Delete(Mapper.Map<Menu>(entity));
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