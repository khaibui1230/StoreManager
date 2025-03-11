using Microsoft.EntityFrameworkCore;
using StoreManager.Model;

namespace StoreManager.Data.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly RestaurantDbContext dbContext;

        public StaffRepository(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Staff staff)
        {
            dbContext.Staffs.Add(staff);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var staffId = await dbContext.Staffs.FindAsync(id);
            if (staffId != null)
            {
                dbContext.Staffs.Remove(staffId);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Staff>> GetAllAsync() => await dbContext.Staffs.ToListAsync();

        public async Task<Staff?> GetByIdAsync(int id) => await dbContext.Staffs.FindAsync(id);

        public async Task UpdateAsync(Staff staff)
        {
            var existingStaff = await dbContext.Staffs.FindAsync(staff.Id);
            if (existingStaff == null)
            {
                throw new Exception("Staff not found");
            }
            existingStaff.Name = staff.Name;
            existingStaff.Role = staff.Role;
            await dbContext.SaveChangesAsync();
        }
    }
}
