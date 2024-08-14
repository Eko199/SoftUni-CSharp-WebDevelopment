namespace HouseRentingSystem.Core.Services.House;

using Contracts.House;
using Infrastructure.Common;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Models.Agent;
using Models.House;

public class HouseService : IHouseService
{
    private readonly IRepository data;

    public HouseService(IRepository data)
    {
        this.data = data;
    }

    public async Task<IEnumerable<HouseIndexServiceModel>> GetLastThreeHousesAsync()
        => await data.All<House>()
            .OrderByDescending(h => h.Id)
            .Select(h => new HouseIndexServiceModel
            {
                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl
            })
            .Take(3)
            .ToListAsync();

    public async Task<IEnumerable<HouseCategoryServiceModel>> GetAllCategoriesAsync()
        => await data.All<Category>()
            .Select(c => new HouseCategoryServiceModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

    public async Task<IEnumerable<string>> GetAllCategoriesNamesAsync()
        => await data.All<Category>().Select(c => c.Name).Distinct().ToListAsync();

    public async Task<bool> CategoryExistsAsync(int id)
        => await data.All<Category>().AnyAsync(c => c.Id == id);

    public async Task<int> Create(HouseFormModel model, int agentId)
    {
        var house = new House
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId,
            AgentId = agentId
        };

        await data.AddAsync(house);
        await data.SaveChangesAsync();

        return house.Id;
    }

    public async Task<AllHousesQueryModel> GetAllAsync(AllHousesQueryModel model)
    {
        IQueryable<House> query = data.All<House>();

        if (!string.IsNullOrWhiteSpace(model.Category))
        {
            query = query.Where(h => h.Category.Name == model.Category);
        }

        if (!string.IsNullOrWhiteSpace(model.SearchTerm))
        {
            query = query.Where(h => h.Title.ToLower().Contains(model.SearchTerm.ToLower())
                                     || h.Address.ToLower().Contains(model.SearchTerm.ToLower())
                                     || h.Description.ToLower().Contains(model.SearchTerm.ToLower()));
        }

        model.TotalHousesCount = await query.CountAsync();

        query = model.Sorting switch
        {
            HouseSorting.Price => query.OrderByDescending(h => h.PricePerMonth),
            HouseSorting.NotRentedFirst => query.OrderBy(h => h.RenterId != null).ThenByDescending(h => h.Id),
            _ => query.OrderByDescending(h => h.Id)
        };

        model.Houses = await ProjectToHouseServiceModel(query
            .Skip((model.CurrentPage - 1) * AllHousesQueryModel.HousesPerPage)
            .Take(AllHousesQueryModel.HousesPerPage))
            .ToListAsync();

        return model;
    }

    public async Task<IEnumerable<HouseServiceModel>> GetAllHousesByAgentIdAsync(int agentId)
        => await ProjectToHouseServiceModel(data
                .All<House>()
                .Where(h => h.AgentId == agentId))
            .ToListAsync();

    public async Task<IEnumerable<HouseServiceModel>> GetAllHousesByUserIdAsync(string userId)
        => await ProjectToHouseServiceModel(data
                .All<House>()
                .Where(h => h.RenterId == userId))
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
                    PhoneNumber = h.Agent.PhoneNumber,
                    Email = h.Agent.User.Email!
                }
            })
            .SingleOrDefaultAsync(h => h.Id == id);

    public async Task<HouseFormModel?> GetFormModelByIdAsync(int id)
    {
        var categories = await GetAllCategoriesAsync();

        return await data.All<House>()
            .Where(h => h.Id == id)
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
        House house = await data.FindAsync<House, int>(id)
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

        House? house = await data.FindAsync<House, int>(houseId);
        return house != null && house.AgentId == agentId;
    }

    public async Task<bool> ExistsByIdAsync(int id) => await data.All<House>().AnyAsync(h => h.Id == id);

    public async Task DeleteAsync(int id)
    {
        var house = await data.FindAsync<House, int>(id) ?? throw new ArgumentException("Invalid house id!");

        data.Delete(house);
        await data.SaveChangesAsync();
    }

    public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
    {
        var house = await data.FindAsync<House, int>(houseId);
        return house != null && house.RenterId == userId;
    }

    public async Task RentAsync(int houseId, string userId)
    {
        var house = await data.FindAsync<House, int>(houseId) ?? throw new ArgumentException("Invalid house id!");

        if (house.RenterId != null)
        {
            throw new ApplicationException("House is already rented!");
        }

        house.RenterId = userId;
        await data.SaveChangesAsync();
    }

    public async Task LeaveAsync(int houseId)
    {
        var house = await data.FindAsync<House, int>(houseId) ?? throw new ArgumentException("Invalid house id!");
        house.RenterId = null;
        await data.SaveChangesAsync();
    }

    private static IQueryable<HouseServiceModel> ProjectToHouseServiceModel(IQueryable<House> query)
        => query.Select(h => new HouseServiceModel
        {
            Id = h.Id,
            Title = h.Title,
            Address = h.Address,
            ImageUrl = h.ImageUrl,
            IsRented = h.RenterId != null,
            PricePerMonth = h.PricePerMonth
        });
}