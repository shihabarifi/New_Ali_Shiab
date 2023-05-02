using Microsoft.AspNetCore.Identity;
using POS.Models;

namespace POS.Seeds
{
    public static class DefaultRole
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            //if (!roleManager.Roles.Any())
            //{
            await roleManager.CreateAsync(new IdentityRole(Helper.Roles.SUPPERADMIN.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Helper.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Helper.Roles.Basic.ToString()));
            //}
        }
    }
}
