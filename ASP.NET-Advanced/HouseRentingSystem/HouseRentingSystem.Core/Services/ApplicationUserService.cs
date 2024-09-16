namespace HouseRentingSystem.Core.Services;

using Microsoft.EntityFrameworkCore;
using Contracts.ApplicationUser;
using HouseRentingSystem.Infrastructure.Models;
using Infrastructure.Common;
using Models.ApplicationUser;

public class ApplicationUserService(IRepository data) : IApplicationUserService
{
    public async Task<bool> UserHasRentsAsync(string userId) => await data.All<House>().AnyAsync(h => h.RenterId == userId);

    public async Task<string?> GetFullNameAsync(string id)
    {
        var user = await data.FindAsync<ApplicationUser>(id)
                   ?? throw new ArgumentException("Invalid user id!");

        return GetFullName(user);
    }

    public async Task<IEnumerable<UserServiceModel>> GetAllAsync()
        => await data.All<ApplicationUser>()
            .Select(u => new UserServiceModel
            {
                Email = u.Email!,
                FullName = GetFullName(u) ?? string.Empty,
                PhoneNumber = u.Agent != null ? u.Agent.PhoneNumber : u.PhoneNumber,
                IsAgent = u.Agent != null
            })
            .ToListAsync();

    private static string? GetFullName(ApplicationUser user) 
        => string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)
        ? null
        : $"{user.FirstName} {user.LastName}";
}