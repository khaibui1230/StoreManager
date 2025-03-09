using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto?> GetMenuItemByIdAsync(int id);
        Task<MenuItemDto> AddMenuItemAsync(MenuItemDto menuItemDto);
        Task<bool> UpdateMenuItemAsync(int id, MenuItemDto menuItemDto);
        Task<bool> DeleteMenuItemAsync(int id);
    }

}
