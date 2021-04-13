using System;
using System.Linq;
using System.Threading.Tasks;
using GastroAvancesWeb;
using GastroAvancesWeb.Models;
//using WebApplication6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication6
{
    public class SeedData
    {
        public static async Task InitializeAsync(
           IServiceProvider services)
        {
            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole<int>>>();
            await EnsureRolesAsync(roleManager);
            var userManager = services
                .GetRequiredService<UserManager<usuario>>();
            await EnsureTestAdminAsync(userManager);
        }


        private static async Task EnsureRolesAsync(
         RoleManager<IdentityRole<int>> roleManager)
        {
            var alreadyExists = await roleManager
                .RoleExistsAsync(Constants.AdministratorRole);
            if (alreadyExists) return;
            await roleManager.CreateAsync(
                new IdentityRole<int>(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(
            UserManager<usuario> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "admin@gastro.com")
                .SingleOrDefaultAsync();
            if (testAdmin != null) return;
            testAdmin = new usuario
            {
                UserName = "admin@gastro.com",
                Email = "admin@gastro.com"
            };
            await userManager.CreateAsync(
                testAdmin, "Admins1234!");
            await userManager.AddToRoleAsync(
                testAdmin, Constants.AdministratorRole);
        }
    }
}
