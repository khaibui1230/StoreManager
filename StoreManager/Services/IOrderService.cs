using StoreManager.DTOs;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task<OrderDto> AddOrderAsync(OrderDto orderDto);
    Task UpdateOrderAsync(int id, OrderDto orderDto);
    Task DeleteOrderAsync(int id);
}