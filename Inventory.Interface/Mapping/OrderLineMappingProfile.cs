using AutoMapper;

using Inventory.Interface.DTO.OrderLine;
using Inventory.Domain.Entities;

namespace Inventory.Interface.Mapping;

public class OrderLineMappingProfile : Profile
{
    public OrderLineMappingProfile()
    {
        CreateMap<OrderLine, OrderLineDTO>();
        CreateMap<OrderLineDTO, OrderLine>();
    }
}
