namespace HouseRentingSystem.Core.Services;

using Contracts.Rent;
using Infrastructure.Common;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Models.Rent;

public class RentService(IRepository data) : IRentService
{
    public async Task<IEnumerable<RentServiceModel>> GetAllAsync()
        => await data.All<House>()
            .Where(h => h.IsApproved && h.RenterId != null)
            .Select(h => new RentServiceModel
            {
                HouseTitle = h.Title,
                HouseImageUrl = h.ImageUrl,
                AgentEmail = h.Agent.User.Email!,
                AgentFullName = $"{h.Agent.User.FirstName} {h.Agent.User.LastName}",
                RenterEmail = h.Renter!.Email!,
                RenterFullName = $"{h.Renter.FirstName} {h.Renter.LastName}"
            })
            .ToListAsync();
}