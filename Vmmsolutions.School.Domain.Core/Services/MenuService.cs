using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class MenuService : Service<Menu>, IMenuService
    {
        //private readonly IMenuRepository _menuRepository;

        public MenuService(IUnitOfWork context, IMenuRepository _menuRepository) : base(context, _menuRepository)
        {
            Validator = new MenuValidator();
        }
    }
}