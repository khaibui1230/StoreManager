using AutoMapper;
using StoreManager.DTOs;
using StoreManager.Model;

namespace StoreManager.Configurations
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add mappings here
            CreateMap<MenuItem, MenuItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }

    }
}
