namespace Microsoft.Extensions.DependencyInjection;

using AspNetCore.Identity;
using EntityFrameworkCore;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Core.Services.Contracts.Agent;
using HouseRentingSystem.Core.Services.Contracts.House;
using HouseRentingSystem.Core.Services.Contracts.Statistic;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Infrastructure.Common;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IHouseService, HouseService>();
        services.AddTransient<IAgentService, AgentService>();
        services.AddTransient<IStatisticService, StatisticService>();

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<HouseRentingDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IRepository, Repository>();

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