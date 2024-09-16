namespace Microsoft.AspNetCore.Builder;

using Identity;
using static HouseRentingSystem.Areas.Admin.AdminConstants;
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

        if (await roleManager.RoleExistsAsync(AdminRole))
        {
            return app;
        }

        var role = new IdentityRole(AdminRole);
        await roleManager.CreateAsync(role);

        var seedData = new SeedData();
        ApplicationUser? admin = await userManager.FindByEmailAsync(seedData.AdminUser.Email!);

        if (admin != null)
        {
            await userManager.AddToRoleAsync(admin, AdminRole);
        }

        return app;
    }
}