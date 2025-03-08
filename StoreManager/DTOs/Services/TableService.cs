using AutoMapper;
using StoreManager.Data.UnitOfWork;
using StoreManager.Model;

namespace StoreManager.DTOs.Services
{
    public class TableService : ITableService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TableService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddTableAsync(Table Table)
        {
            var TableEntity = _mapper.Map<Table>(Table);
            return _unitOfWork.TableRepository.AddAsync(TableEntity);
        }

        public Task DeleteTableAsync(int id)
        {
            var Table = _unitOfWork.TableRepository.GetByIdAsync(id);
            if (Table == null)
            {
                throw new Exception("Table not found");
            }
            else
            {
                return _unitOfWork.TableRepository.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            return await _unitOfWork.TableRepository.GetAllAsync();
        }

        public async Task<Table?> GetTableByIdAsync(int id)
        {
            return await _unitOfWork.TableRepository.GetByIdAsync(id);
        }

        public Task UpdateTableAsync(Table Table)
        {
            var TableEntity = _mapper.Map<Table>(Table);
            return _unitOfWork.TableRepository.UpdateAsync(TableEntity);
        }
    }
}
