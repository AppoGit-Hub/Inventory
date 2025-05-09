using AutoMapper;

using Inventory.Interface.DTO.ManagementType;
using Inventory.Domain.Entities;

namespace Inventory.Interface.Mapping;

public class ManagementTypeMappingProfile : Profile
{
    public ManagementTypeMappingProfile()
    {
        CreateMap<ManagementType, ManagementTypeDTO>();
        CreateMap<ManagementTypeDTO, ManagementType>();
    }
}
