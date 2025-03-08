using AutoMapper;
using StoreManager.Data.UnitOfWork;
using StoreManager.Model;

namespace StoreManager.DTOs.Services
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

        public Task AddStaffAsync(Staff Staff)
        {
            var StaffEntity = _mapper.Map<Staff>(Staff);
            return _unitOfWork.StaffRepository.AddAsync(StaffEntity);
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

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _unitOfWork.StaffRepository.GetAllAsync();
        }

        public async Task<Staff?> GetStaffByIdAsync(int id)
        {
            return await _unitOfWork.StaffRepository.GetByIdAsync(id);
        }

        public Task UpdateStaffAsync(Staff Staff)
        {
            var StaffEntity = _mapper.Map<Staff>(Staff);
            return _unitOfWork.StaffRepository.UpdateAsync(StaffEntity);
        }
    }
}
