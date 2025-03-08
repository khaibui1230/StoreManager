using AutoMapper;
using StoreManager.Data.UnitOfWork;
using StoreManager.Model;

namespace StoreManager.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddOrderAsync(Order order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            return _unitOfWork.OrderRepository.AddAsync(orderEntity);
        }

        public Task DeleteOrderAsync(int id)
        {
            var order = _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            else
            {
                return _unitOfWork.OrderRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _unitOfWork.OrderRepository.GetByIdAsync(id);
        }

        public Task UpdateOrderAsync(Order order)
        {
            var orderEntity = _mapper.Map<Order>(order);
            return _unitOfWork.OrderRepository.UpdateAsync(orderEntity);
        }
    }
}
