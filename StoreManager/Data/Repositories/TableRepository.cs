using Microsoft.EntityFrameworkCore;
using StoreManager.Model;

namespace StoreManager.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantDbContext dbContext;

        public TableRepository(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Table table)
        {
            dbContext.Tables.Add(table);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tableId = await dbContext.Tables.FindAsync(id);
            if (tableId != null)
            {
                dbContext.Tables.Remove(tableId);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Table>> GetAllAsync()=> await dbContext.Tables.ToListAsync();

        public async Task<Table?> GetByIdAsync(int id)
        => await dbContext.Tables.FindAsync(id);

        public async Task UpdateAsync(Table table)
        {
            //fix the update method follow get- update- save    
            var existingTable = await dbContext.Tables.FindAsync(table.Id);
            if (existingTable != null)
            {
                existingTable.Number = table.Number;
                existingTable.Status = table.Status;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Table not found");
            }
        }
    }
}
