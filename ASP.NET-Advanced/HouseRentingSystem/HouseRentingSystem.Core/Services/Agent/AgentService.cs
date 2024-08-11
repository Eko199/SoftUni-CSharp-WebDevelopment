namespace HouseRentingSystem.Core.Services.Agent;

using Contracts.Agent;
using HouseRentingSystem.Core.Models.Agent;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

public class AgentService : IAgentService
{
    private readonly HouseRentingDbContext data;

    public AgentService(HouseRentingDbContext data)
    {
        this.data = data;
    }

    public async Task<bool> ExistsByIdAsync(string userId) => await data.Agents.AnyAsync(a => a.UserId == userId);

    public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber) => await data.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);

    public async Task<bool> UserHasRentsAsync(string userId) => await data.Houses.AnyAsync(h => h.RenterId == userId);

    public async Task CreateAsync(string userId, BecomeAgentFormModel formModel)
    {
        await data.Agents.AddAsync(new Agent
        {
            UserId = userId,
            PhoneNumber = formModel.PhoneNumber,
        });

        await data.SaveChangesAsync();
    }

    public async Task<int?> GetAgentIdAsync(string userId) => (await data.Agents.SingleOrDefaultAsync(a => a.UserId == userId))?.Id;
}