namespace HouseRentingSystem.Core.Services.Contracts.ApplicationUser;

using Models.ApplicationUser;

public interface IApplicationUserService
{
    Task<bool> UserHasRentsAsync(string userId);

    Task<string?> GetFullNameAsync(string id);

    Task<IEnumerable<UserServiceModel>> GetAllAsync();
}