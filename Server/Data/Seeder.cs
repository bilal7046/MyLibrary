using Microsoft.AspNetCore.Identity;

namespace Server.Data
{
    public static class Seeder
    {
        public static async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            string[] roles = { "Admin", "Member" };

            //seed roles
            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    var identityRole = new IdentityRole
                    {
                        Name = role
                    };
                    await roleManager.CreateAsync(identityRole);
                }
            }

            //seed admin
            string adminEmail = "admin@abc.com";
            string adminPassword = "Admin@123";

            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
