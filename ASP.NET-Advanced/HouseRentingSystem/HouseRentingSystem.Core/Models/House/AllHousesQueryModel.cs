namespace HouseRentingSystem.Core.Models.House;

using System.ComponentModel;

public class AllHousesQueryModel
{
    public const int HousesPerPage = 3;

    public string? Category { get; init; }

    [DisplayName("Search by text")]
    public string? SearchTerm { get; init; }

    public HouseSorting Sorting { get; init; } = HouseSorting.Newest;

    public int CurrentPage { get; init; } = 1;

    public int TotalHousesCount { get; set; }

    public IEnumerable<string> Categories { get; set; } = new string[] {};

    public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();
}