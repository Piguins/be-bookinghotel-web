using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Authorization;

public class PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    : DefaultAuthorizationPolicyProvider(options)
{
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName) =>
        await base.GetPolicyAsync(policyName) is { } policy
            ? policy
            : new AuthorizationPolicyBuilder()
                .AddRequirements(
                    policyName switch
                    {
                        nameof(PermissionRequirement.Host) => PermissionRequirement.Host,
                        nameof(PermissionRequirement.Guest) => PermissionRequirement.Guest,
                        _
                            => throw new ArgumentOutOfRangeException(
                                nameof(policyName),
                                policyName,
                                null
                            )
                    }
                )
                .Build();
}
