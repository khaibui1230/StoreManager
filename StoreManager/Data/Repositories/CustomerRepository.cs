using Microsoft.EntityFrameworkCore;
using StoreManager.Model;

namespace StoreManager.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantDbContext dbContext;

        public CustomerRepository(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddCusAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCusAsync(int id)
        {
            //firstorDefalu optimize will be slow than findAsync when find by id
            var customer = await dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                dbContext.Customers.Remove(customer);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Customer>> GetAllCusAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await dbContext.Customers.FindAsync(id);
        }

        public async Task UpdateCusAsync(Customer customer)
        {
            var existingCustomer = await dbContext.Customers.FindAsync(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Address = customer.Address;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Customer not found");
            }
            
        }
    }
}
