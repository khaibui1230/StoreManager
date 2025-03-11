using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public interface ITableService
    {
        Task<IEnumerable<TableDto>> GetAllTableAsync();
        Task<TableDto> GetTableByIdAsync(int id);
        Task<TableDto> AddTableAsync(TableDto table);
        Task<TableDto> UpdateTableAsync(TableDto table);
        Task<bool> DeleteTableAsync(int id);
    }
}
