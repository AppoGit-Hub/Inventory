using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

using Inventory.Interface.Mapping;
using System.Reflection;

namespace Inventory.Interface;

public static class DependencyInjection
{
    public static IServiceCollection AddInterface(
        this IServiceCollection services,
        Action<MvcOptions> controllersConfiguration
    )
    {
        services
            .AddCors(
                options =>
                {
                    options.AddDefaultPolicy(
                        policy =>
                        {
                            policy
                                .WithOrigins(
                                    "http://localhost:4200",
                                    "https://localhost:4200",
                                    "http://locahost:5131",
                                    "https://localhost:7236"
                                )
                                .AllowCredentials()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        }
                    );
                }
            );
        services
            .AddControllers(controllersConfiguration)
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }
            );
        services
            .AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(
                        new UrlSegmentApiVersionReader(),
                        new HeaderApiVersionReader("X-Api-Version")
                    );
                }
            )
            .AddMvc()
            .AddApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                }
            );

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }

    public static WebApplication UseInterface(this WebApplication app)
    {
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.UseCors();

        return app;
    }
}
