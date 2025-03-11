using Microsoft.EntityFrameworkCore;
using StoreManager.Data.Repositories;
using StoreManager.Data;
using StoreManager.Model;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantDbContext _context;

    public OrderRepository(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .Include(o => o.Table)
            .Include(o => o.Staff)
            .ToListAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .Include(o => o.Table)
            .Include(o => o.Staff)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }
    }
}