using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using StoreManager.Data.UnitOfWork;
using StoreManager.DTOs;
using StoreManager.Hubs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IHubContext<StoreHub> _hubContext;

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper, IHubContext<StoreHub> hubContext  )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hubContext = hubContext;
        }


        public async Task<MenuItemDto> AddMenuItemAsync(MenuItemDto menuItemDto)
        {
            // trans the menuItemDto to MenuItem
            var menuItem = _mapper.Map<MenuItem>(menuItemDto);
            // add the menuItem to the database
            await _unitOfWork.MenuRepository.AddAsync(menuItem);
            await _unitOfWork.SaveAsync();

            // send message to all clients
            await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "New Menu has been added");
            // trang the meuItem to menuItemDto
            return _mapper.Map<MenuItemDto>(menuItem);
            

        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var menuItem = await _unitOfWork.MenuRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return false;
            }
            await _unitOfWork.MenuRepository.DeleteAsync(id); // delete the menuItem    
            await _unitOfWork.SaveAsync();

            // send message to all clients
            await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "Menu has been deleted");
            return true;


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

        public async Task<MenuItemDto> UpdateMenuItemAsync(int id, MenuItemDto menuItemDto)
        {
            // check the food is exist or not
            var menuItemExist = await _unitOfWork.MenuRepository.GetByIdAsync(id);
            if (menuItemExist == null)
            {
                return null;
            }
            // trans the data from menuItemDto to menuItem
            _mapper.Map(menuItemDto, menuItemExist);
            await _unitOfWork.MenuRepository.UpdateAsync(menuItemExist);
            await _unitOfWork.SaveAsync();

            // send message to all clients
            await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "Menu has been updated");
            // return the DTO of the menuItem has updated
            return _mapper.Map<MenuItemDto>(menuItemExist);
        }
    }
}
