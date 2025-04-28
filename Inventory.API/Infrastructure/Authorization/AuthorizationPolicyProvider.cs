using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Inventory.API.Infrastructure.Authorization;

//CREDITS: https://www.jerriepelser.com/blog/creating-dynamic-authorization-policies-aspnet-core/
public class AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options, IConfiguration configuration)
    : DefaultAuthorizationPolicyProvider(options)
{
    private readonly AuthorizationOptions _options = options.Value;

    public async override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        // Check static policies first
        AuthorizationPolicy? policy = await base.GetPolicyAsync(policyName);

        if (policy != null) return policy;

        policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            .AddRequirements(
				new HasPermissionRequirement(
					policyName,
					configuration[AuthenticationConfigurationKeys.AUTHORITY]
				)
			)
            .Build();

        // Add policy to the AuthorizationOptions, so we don't have to re-create it each time
        _options.AddPolicy(policyName, policy);

        return policy;
    }
}
