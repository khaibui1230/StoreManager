using Microsoft.EntityFrameworkCore;
using StoreManager.Model;

namespace StoreManager.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext dbContext;

        public OrderRepository(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Order order)
        {
           dbContext.Orders.Add(order);
           await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderId = await dbContext.Orders.FindAsync(id);
            if (orderId != null)
            {
                dbContext.Orders.Remove(orderId);
                await dbContext.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await dbContext.Orders.FindAsync(id);
        }

        public async Task UpdateAsync(Order order)
        {
            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
