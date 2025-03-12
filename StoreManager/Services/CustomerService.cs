using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using StoreManager.Data.UnitOfWork;
using StoreManager.DTOs;
using StoreManager.Hubs;
using StoreManager.Model;

namespace StoreManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHubContext<StoreHub> hubContext;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork,IHubContext<StoreHub> hubContext, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }
        public async Task<CustomerDto> AddCusAsync(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            await unitOfWork.CustomerRepository.AddCusAsync(customer);

            await unitOfWork.SaveAsync();
            await hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "New Customer has been added");
            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> DeleteCusAsync(int id)
        {
            var customer =await unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return false;
            }
            await unitOfWork.CustomerRepository.DeleteCusAsync(id);
            await unitOfWork.SaveAsync();
            await hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "Customer has been deleted");
            return true;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCusAsync()
        {
            var customers = await unitOfWork.CustomerRepository.GetAllCusAsync();
            return mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await unitOfWork.CustomerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return null;
            }
            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateCusAsync(CustomerDto customerDto)
        {
            var existingCustomer = await unitOfWork.CustomerRepository.GetByIdAsync(customerDto.Id);
            if (existingCustomer == null)
            {
                return null;
            }
            var customer = mapper.Map(customerDto, existingCustomer); //update entity from dto  
            if (customer == null)
            {
                return null;
            }
            await unitOfWork.CustomerRepository.UpdateCusAsync(customer);
            await unitOfWork.SaveAsync();
            await hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", "Customer has been updated");
            return mapper.Map<CustomerDto>(customer);
        }
    }
}
