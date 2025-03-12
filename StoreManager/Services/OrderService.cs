using Microsoft.AspNetCore.SignalR;
using StoreManager.Data.UnitOfWork;
using StoreManager.DTOs;
using StoreManager.Hubs;
using StoreManager.Model;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public IHubContext<StoreHub> _hubContext { get; }

    public OrderService(IUnitOfWork unitOfWork, IHubContext<StoreHub> hubContext)
    {
        _unitOfWork = unitOfWork;
        _hubContext = hubContext;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync();
        return orders.Select(o => MapToDto(o));
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
        if (order == null) return null;
        return MapToDto(order);
    }

    public async Task<OrderDto> AddOrderAsync(OrderDto orderDto)
    {
        var order = new Order
        {
            TableId = orderDto.TableId,
            StaffId = orderDto.StaffId,
            OrderDate = orderDto.OrderDate,
            TotalAmount = orderDto.TotalAmount,
            Status = orderDto.Status, // Chuỗi "Pending" được giữ nguyên
            OrderItems = orderDto.OrderItems.Select(oi => new OrderItem
            {
                MenuItemId = oi.MenuItemId,
                Quantity = oi.Quantity,
                Price = oi.Price
            }).ToList()
        };

        await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveAsync();

        //send message to all clients   
        await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "New order has been added");

        return await GetOrderByIdAsync(order.Id);
    }

    public async Task UpdateOrderAsync(int id, OrderDto orderDto)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
        if (order == null) throw new Exception("Order not found");

        order.TableId = orderDto.TableId;
        order.StaffId = orderDto.StaffId;
        order.OrderDate = orderDto.OrderDate;
        order.Status = orderDto.Status;
        order.TotalAmount = orderDto.TotalAmount;

        // Xử lý OrderItems (có thể xóa và thêm lại)
        order.OrderItems.Clear();
        order.OrderItems.AddRange(orderDto.OrderItems.Select(oi => new OrderItem
        {
            MenuItemId = oi.MenuItemId,
            Quantity = oi.Quantity,
            Price = oi.Price
        }));

        await _unitOfWork.OrderRepository.UpdateAsync(order);
        await _unitOfWork.SaveAsync();

        //send message to all clients
        await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "Order has been updated");
    }

    

    public async Task DeleteOrderAsync(int id)
    {
        await _unitOfWork.OrderRepository.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        //send message to all clients   
        await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "The order has been delete");
    }

    private OrderDto MapToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            TableId = order.TableId,
            StaffId = order.StaffId,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            OrderItems = order.OrderItems.Select(oi => new OrderItemDto
            {
                Id = oi.Id,
                MenuItemId = oi.MenuItemId,
                MenuItemName = oi.MenuItem?.Name, // Lấy tên từ MenuItem
                Quantity = oi.Quantity,
                Price = oi.Price
            }).ToList()
        };
    }
}