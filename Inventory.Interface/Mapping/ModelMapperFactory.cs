using AutoMapper;

namespace Inventory.Interface.Mapping;

public static class ModelMapperFactory
{
    public static IMapper CreateMappers(IServiceProvider provider)
    {
        var config = new MapperConfiguration(
            cfg =>
            {
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(provider, type));
                cfg.AddMaps(typeof(ModelMapperFactory).Assembly);
            }
        );
        
        return config.CreateMapper();
    }
}
