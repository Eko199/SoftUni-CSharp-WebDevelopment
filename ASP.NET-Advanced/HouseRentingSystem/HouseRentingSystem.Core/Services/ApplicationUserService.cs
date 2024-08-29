using HouseRentingSystem.Core.Services.Contracts.ApplicationUser;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;

namespace HouseRentingSystem.Core.Services;

public class ApplicationUserService(IRepository data) : IApplicationUserService
{
    public async Task<string?> GetFullNameAsync(string id)
    {
        var user = await data.FindAsync<ApplicationUser>(id)
                   ?? throw new ArgumentException("Invalid user id!");

        return string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)
            ? null
            : user.FirstName + " " + user.LastName;
    }
}