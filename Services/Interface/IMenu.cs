using ProgrammingCodePro.Models;

namespace ProgrammingCodePro.Service.Interface
{
    public interface IMenu
    {
        Task<List<MenuDto>> GetMenu(int idRoleDto);
        Task<bool> PostMenus(List<MenuDto> menuDto);
    }
}
