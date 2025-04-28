using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using Inventory.API.Infrastructure;
using Inventory.API.Infrastructure.Authorization;
using Inventory.API.Infrastructure.Filters;
using Inventory.Business;
using Inventory.DAL;
using Inventory.Interface;
using Inventory.Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(
    logging =>
    {
        logging.AddConsole();
        logging.AddDebug();
    }
);
builder.Services.AddBusiness();
builder.Services.AddDAL(builder.Configuration);
builder.Services.AddShared();
builder.Services.AddInterface(
    options =>
    {
        options.Filters.Add<ConcurrencyExceptionFilter>();
        options.Filters.Add<EntityNotFoundExceptionFilter>();
    }
);
builder.Services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.Authority = builder.Configuration[AuthenticationConfigurationKeys.AUTHORITY];
            options.Audience = builder.Configuration[AuthenticationConfigurationKeys.AUDIENCE];
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimTypes.NameIdentifier
            };
        }
    );
var app = builder.Build();

app.UseInterface();

app.Run();
