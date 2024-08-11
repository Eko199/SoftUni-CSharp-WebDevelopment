using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Services.Contracts.Agent;

public interface IAgentService
{
    Task<bool> ExistsByIdAsync(string userId);

    Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);

    Task<bool> UserHasRentsAsync(string userId);

    Task CreateAsync(string userId, BecomeAgentFormModel formModel);

    Task<int?> GetAgentIdAsync(string userId);
}