using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManager.DTOs;
using StoreManager.Model;
using StoreManager.Services;

namespace StoreManager.Controllers
{
    [Authorize]
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
            var menuItems = await menuService.GetAllAsync();
            if (menuItems == null || !menuItems.Any())
            {
                return NotFound("No menu items found.");
            }
            return Ok(menuItems);
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
            if (menuItemDto == null)
            {
                return BadRequest("Menu item data is required.");
            }
            var createdMenuItem = await menuService.AddMenuItemAsync(menuItemDto);
            if (createdMenuItem == null)
            {
                return BadRequest("Failed to create menu item.");
            }
            return CreatedAtAction(nameof(GetMenuItem), new { id = createdMenuItem.Id }, createdMenuItem);

        }

        // PUT: api/menu/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemDto menuItemDto)
        {
            if (menuItemDto == null)
            {
                return BadRequest("Menu item data is required.");
            }
            if (id != menuItemDto.Id)
            {
                return BadRequest("Menu item Id in URL does not match the Id in the request body.");
            }
            var updatedItem = await menuService.UpdateMenuItemAsync(id, menuItemDto);
            if (updatedItem == null)
            {
                return NotFound($"Menu item with ID {id} not found.");
            }
            return Ok(updatedItem);
        }
        //DELETE: api/menu/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var deleted = await menuService.DeleteMenuItemAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
