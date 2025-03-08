using StoreManager.Data.Repositories;

namespace StoreManager.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext dbContext;

        public IMenuRepository MenuRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IStaffRepository StaffRepository { get; }
        public ITableRepository TableRepository { get; }


        public UnitOfWork(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
            MenuRepository = new MenuRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            StaffRepository = new StaffRepository(dbContext);
            TableRepository = new TableRepository(dbContext);
        }

       
        public void Dispose()
        {
            // close the context when the unit of work is disposed
            dbContext.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
