namespace HouseRentingSystem.Core.Services.Contracts.ApplicationUser;

public interface IApplicationUserService
{
    Task<string?> GetFullNameAsync(string id);
}