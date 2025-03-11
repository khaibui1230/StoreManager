using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaffsAsync();
        Task<StaffDto> GetStaffByIdAsync(int id);
        Task<StaffDto> AddStaffAsync(StaffDto staff);
        Task<StaffDto> UpdateStaffAsync(StaffDto staffDto);
        Task<bool> DeleteStaffAsync(int id);
    }
}
