using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

using Inventory.DAL.Repositories;
using Inventory.IDAL;

namespace Inventory.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<IMongoClient>(
                _ => new MongoClient(
                    configuration.GetConnectionString("DatabaseConnection")
                )
            );

        services
			.AddSingleton<IMongoDatabase>(
				provider => provider
					.GetService<IMongoClient>()!
					.GetDatabase(configuration.GetValue<string>("DatabaseName"))
			);

        ConfigureConventions();

        services.AddScoped<IDiagnosticsRepository, DiagnosticsRepository>();

        return services;
    }

    private static void ConfigureConventions()
    {
        ConventionRegistry.Register(
            "convention",
            new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(MongoDB.Bson.BsonType.String),
                new NamedIdMemberConvention("Id", "_id"),
                new StringIdStoredAsObjectIdConvention()
            },
            _ => true
        );
    }
}
