using AutoMapper;
using StoreManager.Data.UnitOfWork;
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
        public async Task AddMenuItemAsync(MenuItem menuItem)
        {
            var menuItemEntity = _mapper.Map<MenuItem>(menuItem);
            await _unitOfWork.MenuRepository.AddAsync(menuItemEntity);
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = _unitOfWork.MenuRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                throw new Exception("Menu item not found");
            }
            else
            {
                await _unitOfWork.MenuRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _unitOfWork.MenuRepository.GetAllAsync();
        }

        public Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            return _unitOfWork.MenuRepository.GetByIdAsync(id);
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            var menuItemEntity = _mapper.Map<MenuItem>(menuItem);
            await _unitOfWork.MenuRepository.UpdateAsync(menuItemEntity);
        }
    }
}
