using Microsoft.AspNetCore.Identity;
using POS.Constants;
using POS.Models;
using POS.ViewModel;
using System.Security.Claims;
using static POS.Models.Helper;

namespace POS.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefultUser = new ApplicationUser
            {
                UserName = UserNameBasic,
                Email = EmailBasic,
                Name = NameBasic,
                ImageUser = "69805409-b5a1-4154-ad10-762baf4532a2.png",
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = userManager.FindByEmailAsync(DefultUser.Email);
            if (user.Result == null)
            {
                await userManager.CreateAsync(DefultUser, PasswordBasic);
                await userManager.AddToRolesAsync(DefultUser, new List<string> { Helper.Roles.Basic.ToString() });
            }
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = UserName,
                Email = Email,
                Name = Name,
             
                ImageUser = "69805409-b5a1-4154-ad10-762baf4532a2.png",
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(DefaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(DefaultUser, Passwordadmin);
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { Helper.Roles.SUPPERADMIN.ToString() });
            }

            await roleManager.SeedClaimsAsync();
        }
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = UserNameadmin,
                Email = Emailadmin,
                Name = Nameadmin,
                ImageUser = "69805409-b5a1-4154-ad10-762baf4532a2.png",
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(DefaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(DefaultUser, Password);
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { Helper.Roles.Admin.ToString() });
            }

            await roleManager.SeedClaimsAsync();
        }


        public static async Task SeedClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SUPPERADMIN.ToString());
            var modules = Enum.GetValues(typeof(PermissionModuleName));
            foreach (var module in modules)
                await roleManager.AddPermissionClaims(adminRole, module.ToString());
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsFromModule(module);

            foreach (var permission in allPermissions)
                if (!allClaims.Any(x => x.Type == Helper.Permission && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim(Helper.Permission, permission));
        }
    }
}
