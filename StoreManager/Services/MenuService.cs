using AutoMapper;
using StoreManager.Data.UnitOfWork;
using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MenuItemDto> AddMenuItemAsync(MenuItemDto menuItemDto)
        {
            // trans the menuItemDto to MenuItem
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);
            // add the menuItem to the database
            await _unitOfWork.MenuRepository.AddAsync(menuItem);
            await _unitOfWork.SaveAsync();
            // trang the meuItem to menuItemDto
            return _mapper.Map<MenuItemDto>(menuItem);

        }

        public Task<bool> DeleteMenuItemAsync(int id)
        {
            throw new NotImplementedException();
        }
        // get all the food items
        public async Task<IEnumerable<MenuItemDto>> GetAllAsync()
        {
            var menuItems = await _unitOfWork.MenuRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
        }

        public async Task<MenuItemDto?> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await _unitOfWork.MenuRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return null;
            }
            return _mapper.Map<MenuItemDto>(menuItem);
        }

        public Task<bool> UpdateMenuItemAsync(int id, MenuItemDto menuItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
