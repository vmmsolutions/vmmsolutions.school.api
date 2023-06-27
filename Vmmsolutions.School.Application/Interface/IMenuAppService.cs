using Vmmsolutions.School.Application.Dto.Menus;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IMenuAppService
    {
        MenuDto GetById(Guid id);
        IEnumerable<MenuDto> GetAll(Guid id);
        MenuDto Insert(MenuPostDto obj);
        void Update(Guid id, MenuPatchDto obj);
        void Delete(Guid id);
    }
}
