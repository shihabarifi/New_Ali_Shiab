using Microsoft.AspNetCore.Authorization;
using POS.Models;

namespace POS.Permission
{
    public class PermissionAuthorizationHandler: AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                        PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }
                var Permissionss = context.User.Claims
                    .Where(x => x.Type == Helper.Permission && x.Value == requirement.Permission && x.Issuer == "LOCAL AUTHORITY");
                if (Permissionss.Any())
                {
                    context.Succeed(requirement);
                    return;
                }
            


        }
    }
}
