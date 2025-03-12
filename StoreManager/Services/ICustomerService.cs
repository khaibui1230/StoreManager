using StoreManager.DTOs;

namespace StoreManager.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCusAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task<CustomerDto> AddCusAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateCusAsync(CustomerDto customerDto);
        Task<bool> DeleteCusAsync(int id);
    }
}
