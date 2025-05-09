using AutoMapper;

using Inventory.Interface.DTO.Supplier;
using Inventory.Domain.Entities;

namespace Inventory.Interface.Mapping;

public class SupplierMappingProfile : Profile
{
    public SupplierMappingProfile()
    {
        CreateMap<Supplier, SupplierDTO>();
        CreateMap<SupplierDTO, Supplier>();
        CreateMap<Supplier, SupplierMinimalDTO>();
        CreateMap<SupplierCreationDTO, Supplier>();
        CreateMap<SupplierUpdateDTO, Supplier>();
    }
}
