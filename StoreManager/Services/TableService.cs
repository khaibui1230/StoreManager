using AutoMapper;
using StoreManager.Data.UnitOfWork;
using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Services
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

        public async Task<TableDto> AddTableAsync(TableDto tableDto)
        {
            var TableEntity = _mapper.Map<Table>(tableDto);
            await _unitOfWork.TableRepository.AddAsync(TableEntity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TableDto>(TableEntity);
            
        }

        public Task<TableDto> AddTableAsync(Table table)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            var existingTable = await _unitOfWork.TableRepository.GetByIdAsync(id);
            if (existingTable == null)
            {
                return false;
            }
            await _unitOfWork.TableRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<TableDto>> GetAllTableAsync()
        {
            var tables = await _unitOfWork.TableRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<TableDto> GetTableByIdAsync(int id)
        {
            var table = await _unitOfWork.TableRepository.GetByIdAsync(id);
            return _mapper.Map<TableDto>(table);
        }

        
        //use the Get-Update-Save pattern
        public async Task<TableDto> UpdateTableAsync(TableDto tableDto)
        {
            //Get 
            var existingTable = await _unitOfWork.TableRepository.GetByIdAsync(tableDto.Id);
            if (existingTable == null)
            {
                return null;
            }
            //Update
            _mapper.Map(tableDto, existingTable); // Cập nhật các thuộc tính từ DTO vào entity
            //Save
            await _unitOfWork.TableRepository.UpdateAsync(existingTable);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TableDto>(existingTable);
        }         
    }
}
