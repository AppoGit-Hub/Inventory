using AutoMapper;

using Inventory.Interface.DTO.Model;
using Inventory.Domain.Entities;

namespace Inventory.Interface.Mapping;

public class ModelMappingProfile : Profile
{
    public ModelMappingProfile()
    {
        CreateMap<Model, ModelDTO>();
        CreateMap<ModelDTO, Model>();
        CreateMap<Model, ModelMinimalDTO>();
        CreateMap<ModelCreationDTO, Model>();
        CreateMap<ModelUpdateDTO, Model>();
    }
}
