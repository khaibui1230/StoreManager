using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Model;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenu ()
        {
            return Ok(await menuService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            var menuItem = await menuService.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMenuItem(MenuItemDto menuItemDto)
        {
            await menuService.AddMenuItemAsync(menuItemDto);
            return CreatedAtAction(nameof(GetMenu), new { id = menuItemDto.Id }, menuItemDto);
        }
    }
}
