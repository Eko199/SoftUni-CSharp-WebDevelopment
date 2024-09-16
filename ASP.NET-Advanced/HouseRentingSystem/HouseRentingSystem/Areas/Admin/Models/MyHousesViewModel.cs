namespace HouseRentingSystem.Areas.Admin.Models;

using Core.Models.House;

public class MyHousesViewModel
{
    public IEnumerable<HouseServiceModel> AddedHouses { get; set; } = new List<HouseServiceModel>();

    public IEnumerable<HouseServiceModel> RentedHouses { get; set; } = new List<HouseServiceModel>();
}