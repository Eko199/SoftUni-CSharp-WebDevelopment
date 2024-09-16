namespace HouseRentingSystem.Core.Services.Contracts.House;

using Models.House;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> GetLastThreeHousesAsync();

    Task<IEnumerable<HouseCategoryServiceModel>> GetAllCategoriesAsync();

    Task<IEnumerable<string>> GetAllCategoriesNamesAsync();

    Task<bool> CategoryExistsAsync(int id);

    Task<int> CreateAsync(HouseFormModel model, int agentId);

    Task<AllHousesQueryModel> GetAllAsync(AllHousesQueryModel model);

    Task<IEnumerable<HouseServiceModel>> GetAllHousesByAgentIdAsync(int agentId);

    Task<IEnumerable<HouseServiceModel>> GetAllHousesByUserIdAsync(string userId);

    Task<HouseDetailsServiceModel?> GetDetailsByIdAsync(int id);

    Task<HouseFormModel?> GetFormModelByIdAsync(int id);

    Task EditAsync(int id, HouseFormModel model);

    Task<bool> HouseHasAgentWithUserId(int houseId, string userId);

    Task<bool> ExistsByIdAsync(int id);

    Task DeleteAsync(int id);

    Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId);

    Task RentAsync(int houseId, string userId);

    Task LeaveAsync(int houseId);

    Task<IEnumerable<HouseApprovalModel>> GetAllForApprovalAsync();

    Task ApproveAsync(int houseId);
}