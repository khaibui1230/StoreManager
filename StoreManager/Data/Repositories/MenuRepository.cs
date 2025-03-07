using Microsoft.EntityFrameworkCore;
using StoreManager.Model;

namespace StoreManager.Data.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public MenuRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(MenuItem menuItem)
        {
            _dbContext.MenuItems.Add(menuItem); // Add the new menu item to the database
            await _dbContext.SaveChangesAsync();// Save the item
        }

        public async Task DeleteAsync(int id)
        {
            // initial the menu item 
            var menuItem = await _dbContext.MenuItems.FindAsync(id);
            if(menuItem != null)
            {
                _dbContext.MenuItems.Remove(menuItem); // Remove the menu item from the database
                await _dbContext.SaveChangesAsync(); // Save the changes
            }
        }

        public async Task<IEnumerable<MenuItem>> GetAllAsync()
        {
            return await _dbContext.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _dbContext.MenuItems.FindAsync(id);
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _dbContext.MenuItems.Update(menuItem); // Update the new menu item to the database
            await _dbContext.SaveChangesAsync();// Save the item
        }
    }
}
