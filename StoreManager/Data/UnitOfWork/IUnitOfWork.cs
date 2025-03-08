using StoreManager.Data.Repositories;

namespace StoreManager.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITableRepository TableRepository { get; }
        IOrderRepository OrderRepository { get; }
        IStaffRepository StaffRepository { get; }
        IMenuRepository MenuRepository { get; } 
        Task<int> SaveAsync();
    }
}
