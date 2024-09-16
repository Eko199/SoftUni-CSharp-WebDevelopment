namespace HouseRentingSystem.Core.Services;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Contracts.ApplicationUser;
using Contracts.House;
using Infrastructure.Common;
using Infrastructure.Models;
using Models.Agent;
using Models.House;

public class HouseService(IRepository data, IApplicationUserService userService, IMapper mapper) : IHouseService
{
    public async Task<IEnumerable<HouseIndexServiceModel>> GetLastThreeHousesAsync()
        => await data.All<House>()
            .Where(h => h.IsApproved)
            .OrderByDescending(h => h.Id)
            .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
            .Take(3)
            .ToListAsync();

    public async Task<IEnumerable<HouseCategoryServiceModel>> GetAllCategoriesAsync()
        => await data.All<Category>()
            .ProjectTo<HouseCategoryServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<IEnumerable<string>> GetAllCategoriesNamesAsync()
        => await data.All<Category>().Select(c => c.Name).Distinct().ToListAsync();

    public async Task<bool> CategoryExistsAsync(int id)
        => await data.All<Category>().AnyAsync(c => c.Id == id);

    public async Task<int> CreateAsync(HouseFormModel model, int agentId)
    {
        var house = new House
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            IsApproved = false,
            CategoryId = model.CategoryId,
            AgentId = agentId
        };

        await data.AddAsync(house);
        await data.SaveChangesAsync();

        return house.Id;
    }

    public async Task<AllHousesQueryModel> GetAllAsync(AllHousesQueryModel model)
    {
        IQueryable<House> query = data.All<House>().Where(h => h.IsApproved);

        if (!string.IsNullOrWhiteSpace(model.Category))
        {
            query = query.Where(h => h.Category.Name == model.Category);
        }

        if (!string.IsNullOrWhiteSpace(model.SearchTerm))
        {
            query = query.Where(h => h.Title.Contains(model.SearchTerm, StringComparison.CurrentCultureIgnoreCase)
                                     || h.Address.Contains(model.SearchTerm, StringComparison.CurrentCultureIgnoreCase)
                                     || h.Description.Contains(model.SearchTerm, StringComparison.CurrentCultureIgnoreCase));
        }

        model.TotalHousesCount = await query.CountAsync();

        query = model.Sorting switch
        {
            HouseSorting.Price => query.OrderBy(h => h.PricePerMonth),
            HouseSorting.NotRentedFirst => query.OrderBy(h => h.RenterId != null).ThenByDescending(h => h.Id),
            _ => query.OrderByDescending(h => h.Id)
        };

        model.Houses = await query
            .Skip((model.CurrentPage - 1) * AllHousesQueryModel.HousesPerPage)
            .Take(AllHousesQueryModel.HousesPerPage)
            .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

        return model;
    }

    public async Task<IEnumerable<HouseServiceModel>> GetAllHousesByAgentIdAsync(int agentId)
        => await data
            .All<House>()
            .Where(h => h.IsApproved && h.AgentId == agentId)
            .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<IEnumerable<HouseServiceModel>> GetAllHousesByUserIdAsync(string userId)
        => await data
            .All<House>()
            .Where(h => h.IsApproved && h.RenterId == userId)
            .ProjectTo<HouseServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<HouseDetailsServiceModel?> GetDetailsByIdAsync(int id)
        => await data.All<House>()
            .Select(h => new HouseDetailsServiceModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null,
                Category = h.Category.Name,
                Agent = new AgentServiceModel
                {
                    FullName = userService.GetFullNameAsync(h.Agent.UserId).Result,
                    PhoneNumber = h.Agent.PhoneNumber,
                    Email = h.Agent.User.Email!
                }
            })
            .SingleOrDefaultAsync(h => h.Id == id);

    public async Task<HouseFormModel?> GetFormModelByIdAsync(int id)
    {
        var categories = await GetAllCategoriesAsync();

        return await data.All<House>()
            .Where(h => h.Id == id && h.IsApproved)
            .Select(h => new HouseFormModel
            {
                Title = h.Title,
                Address = h.Address,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                CategoryId = h.CategoryId,
                Categories = categories
            })
            .SingleOrDefaultAsync();
    }

    public async Task EditAsync(int id, HouseFormModel model)
    {
        House house = await data.FindAsync<House>(id)
            ?? throw new ArgumentException("Invalid house id!");

        house.Title = model.Title;
        house.Address = model.Address;
        house.Description = model.Description;
        house.ImageUrl = model.ImageUrl;
        house.PricePerMonth = model.PricePerMonth;
        house.CategoryId = model.CategoryId;

        await data.SaveChangesAsync();
    }

    public async Task<bool> HouseHasAgentWithUserId(int houseId, string userId)
    {
        int? agentId = (await data.All<Agent>().SingleOrDefaultAsync(a => a.UserId == userId))?.Id;

        if (!agentId.HasValue)
        {
            return false;
        }

        House? house = await data.FindAsync<House>(houseId);
        return house != null && house.AgentId == agentId;
    }

    public async Task<bool> ExistsByIdAsync(int id) => await data.All<House>().AnyAsync(h => h.Id == id);

    public async Task DeleteAsync(int id)
    {
        var house = await data.FindAsync<House>(id) ?? throw new ArgumentException("Invalid house id!");

        data.Delete(house);
        await data.SaveChangesAsync();
    }

    public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
    {
        var house = await data.FindAsync<House>(houseId);
        return house != null && house.RenterId == userId;
    }

    public async Task RentAsync(int houseId, string userId)
    {
        var house = await data.FindAsync<House>(houseId) ?? throw new ArgumentException("Invalid house id!");

        if (house.RenterId != null)
        {
            throw new ApplicationException("House is already rented!");
        }

        house.RenterId = userId;
        await data.SaveChangesAsync();
    }

    public async Task LeaveAsync(int houseId)
    {
        var house = await data.FindAsync<House>(houseId) ?? throw new ArgumentException("Invalid house id!");
        house.RenterId = null;
        await data.SaveChangesAsync();
    }

    public async Task<IEnumerable<HouseApprovalModel>> GetAllForApprovalAsync()
        => await data.All<House>()
            .Where(h => !h.IsApproved)
            .Select(h => new HouseApprovalModel
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                Category = h.Category.Name,
                ImageUrl = h.ImageUrl,
                Description = h.Description,
                PricePerMonth = h.PricePerMonth,
                AgentEmail = h.Agent.User.Email!
            })
            .ToListAsync();

    public async Task ApproveAsync(int houseId)
    {
        var house = await data.FindAsync<House>(houseId) ?? throw new ArgumentException("Invalid house id!");

        if (!house.IsApproved)
        {
            house.IsApproved = true;
            await data.SaveChangesAsync();
        }
    }
}