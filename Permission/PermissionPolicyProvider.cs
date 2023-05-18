
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using POS.Models;

namespace POS.Permission
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }
       

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);   
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()=> FallbackPolicyProvider.GetFallbackPolicyAsync();
       

       

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(Helper.Permission, StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new PermissionRequirement(policyName));
                return Task.FromResult(policy.Build()); 
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

    }
}
