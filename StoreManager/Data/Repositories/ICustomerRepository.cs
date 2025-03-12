using StoreManager.Model;

namespace StoreManager.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCusAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task AddCusAsync(Customer customer);
        Task UpdateCusAsync(Customer customer);
        Task DeleteCusAsync(int id);
    }
}
