namespace HouseRentingSystem.Core.Services.Contracts.Rent;

using Models.Rent;

public interface IRentService
{
    Task<IEnumerable<RentServiceModel>> GetAllAsync();
}