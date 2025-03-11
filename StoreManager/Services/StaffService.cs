using AutoMapper;
using StoreManager.Data.UnitOfWork;
using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public class StaffService : IStaffService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<StaffDto> AddStaffAsync(StaffDto staffDto)
        {
            var staff = new Staff
            {
                Name = staffDto.Name,
                Role = staffDto.Role
            };
            await _unitOfWork.StaffRepository.AddAsync(staff);
            staffDto.Id = staff.Id; // Đảm bảo Id được gán sau khi lưu
            return staffDto;
        }

        public Task DeleteStaffAsync(int id)
        {
            var Staff = _unitOfWork.StaffRepository.GetByIdAsync(id);
            if (Staff == null)
            {
                throw new Exception("Staff not found");
            }
            else
            {
                return _unitOfWork.StaffRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<Staff>> GetAllStaffsAsync()
        {
            return await _unitOfWork.StaffRepository.GetAllAsync();
        }

        public async Task<StaffDto> GetStaffByIdAsync(int id)
        {
            var staffEntity = await _unitOfWork.StaffRepository.GetByIdAsync(id);
            if (staffEntity == null)
            {
                return null;
            }
            return _mapper.Map<StaffDto>(staffEntity);
        }

        public async Task<StaffDto> UpdateStaffAsync(StaffDto staffDto)
        {
            var staffEntity = _mapper.Map<Staff>(staffDto);
            if (staffEntity == null)
            {
                return null;
            }
            staffEntity.Name = staffDto.Name;
            staffEntity.Role = staffDto.Role;
            await _unitOfWork.StaffRepository.UpdateAsync(staffEntity);
            return staffDto;
        }
    }
}
