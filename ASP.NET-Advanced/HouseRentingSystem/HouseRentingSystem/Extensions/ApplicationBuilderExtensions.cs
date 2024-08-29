namespace Microsoft.AspNetCore.Builder;

using Identity;
using HouseRentingSystem.Infrastructure.Models;
using HouseRentingSystem.Infrastructure.SeedDb;

public static class ApplicationBuilderExtensions
{
    public static async Task<IApplicationBuilder> SeedAdminAsync(this IApplicationBuilder app)
    {
        using var scopedServices = app.ApplicationServices.CreateScope();
        var services = scopedServices.ServiceProvider;

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        const string roleName = "Administrator";

        if (await roleManager.RoleExistsAsync(roleName))
        {
            return app;
        }

        var role = new IdentityRole(roleName);
        await roleManager.CreateAsync(role);

        var seedData = new SeedData();
        ApplicationUser admin = await userManager.FindByEmailAsync(seedData.AdminUser.Email!)
                                ?? throw new ApplicationException("Admin doesn't exist!");

        await userManager.AddToRoleAsync(admin, roleName);
        return app;
    }
}