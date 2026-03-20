using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
    {
        var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger("SeedData");

        try
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "Customer", "User" };

            // Create Roles
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Admin User
            var admin = new IdentityUser { UserName = "admin@test.com", Email = "admin@test.com" };
            if (await userManager.FindByEmailAsync(admin.Email) == null)
            {
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Customer User
            var customer = new IdentityUser { UserName = "customer@test.com", Email = "customer@test.com" };
            if (await userManager.FindByEmailAsync(customer.Email) == null)
            {
                await userManager.CreateAsync(customer, "Customer@123");
                await userManager.AddToRoleAsync(customer, "Customer");
            }

            // Normal User
            var user = new IdentityUser { UserName = "user@test.com", Email = "user@test.com" };
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, "User@123");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
        catch (Exception ex)
        {
            // Log and swallow exceptions so app startup doesn't crash when DB is unavailable
            logger?.LogWarning(ex, "Seeding roles/users failed. This may be transient and can be retried later.");
        }
    }
}