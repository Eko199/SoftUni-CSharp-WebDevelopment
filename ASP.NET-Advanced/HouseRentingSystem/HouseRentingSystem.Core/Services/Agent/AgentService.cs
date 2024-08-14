namespace HouseRentingSystem.Core.Services.Agent;

using Contracts.Agent;
using HouseRentingSystem.Core.Models.Agent;
using Infrastructure.Common;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

public class AgentService : IAgentService
{
    private readonly IRepository data;

    public AgentService(IRepository data)
    {
        this.data = data;
    }

    public async Task<bool> ExistsByIdAsync(string userId) => await data.All<Agent>().AnyAsync(a => a.UserId == userId);

    public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber) => await data.All<Agent>().AnyAsync(a => a.PhoneNumber == phoneNumber);

    public async Task<bool> UserHasRentsAsync(string userId) => await data.All<House>().AnyAsync(h => h.RenterId == userId);

    public async Task CreateAsync(string userId, BecomeAgentFormModel formModel)
    {
        await data.AddAsync(new Agent
        {
            UserId = userId,
            PhoneNumber = formModel.PhoneNumber,
        });

        await data.SaveChangesAsync();
    }

    public async Task<int?> GetAgentIdAsync(string userId) => (await data.All<Agent>().SingleOrDefaultAsync(a => a.UserId == userId))?.Id;
}