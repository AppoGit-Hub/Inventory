using AutoMapper;

using Inventory.Interface.DTO.Order;
using Inventory.Domain.Entities;

namespace Inventory.Interface.Mapping;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();
        CreateMap<Order, OrderMinimalDTO>();
        CreateMap<OrderCreationDTO, Order>();
        CreateMap<OrderUpdateDTO, Order>();
    }
}
