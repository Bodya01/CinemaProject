
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CinemaProject.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            string adminEmail = "Admin";
            string password = "qW!1q532g";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role("admin"));
            }
            if (await roleManager.FindByNameAsync("employee") == null)
            {
                await roleManager.CreateAsync(new Role("employee"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
