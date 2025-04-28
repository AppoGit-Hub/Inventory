using Inventory.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Inventory.API.Infrastructure.Authorization;

public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
    {
        // If user does not have the scope claim, get out of here
        if (!context.User.HasClaim(claim => claim.Type == Permissions.ClaimType && claim.Issuer == requirement.Issuer))
            return Task.CompletedTask;

        // Split the scopes string into an array
        IEnumerable<string> scopes = context.User.Claims
            .Where(claim => claim.Type == Permissions.ClaimType && claim.Issuer == requirement.Issuer)
            .Select(claim => claim.Value);

        // Succeed if the scope array contains the required scope
        if (scopes.Any(scope => scope.Equals(requirement.Scope, StringComparison.InvariantCultureIgnoreCase)))
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
