namespace Microsoft.Extensions.DependencyInjection;

using AspNetCore.Identity;
using EntityFrameworkCore;
using HouseRentingSystem.Core.Services.Agent;
using HouseRentingSystem.Core.Services.Contracts.Agent;
using HouseRentingSystem.Core.Services.Contracts.House;
using HouseRentingSystem.Core.Services.House;
using HouseRentingSystem.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IHouseService, HouseService>();
        services.AddTransient<IAgentService, AgentService>();

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<HouseRentingDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }
    public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<HouseRentingDbContext>();

        return services;
    }
}