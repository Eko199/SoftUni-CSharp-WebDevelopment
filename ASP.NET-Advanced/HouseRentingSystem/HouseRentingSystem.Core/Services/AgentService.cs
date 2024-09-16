namespace HouseRentingSystem.Core.Services;

using Microsoft.EntityFrameworkCore;
using Contracts.Agent;
using Models.Agent;
using Infrastructure.Common;
using Infrastructure.Models;

public class AgentService(IRepository data) : IAgentService
{
    public async Task<bool> ExistsByIdAsync(string userId) => await data.All<Agent>().AnyAsync(a => a.UserId == userId);

    public async Task<bool> AgentWithPhoneNumberExistsAsync(string phoneNumber) => await data.All<Agent>().AnyAsync(a => a.PhoneNumber == phoneNumber);

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