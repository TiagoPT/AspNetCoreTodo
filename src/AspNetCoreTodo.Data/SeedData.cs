using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreTodo.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services, IConfiguration configuration)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager, configuration);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

            if (alreadyExists)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }
        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == configuration[Constants.AdminstratorEmailConfigKey])
                .SingleOrDefaultAsync();

            if (testAdmin != null)
            {
                return;
            }

            testAdmin = new ApplicationUser
            {
                UserName = configuration[Constants.AdminstratorEmailConfigKey],
                Email = configuration[Constants.AdminstratorEmailConfigKey],
                EmailConfirmed = true
            };
            
            var userCreateResponse = await userManager.CreateAsync(testAdmin, configuration[Constants.AdminstratorPasswordConfigKey]);
            var addRoleResponse = await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }
    }
}
