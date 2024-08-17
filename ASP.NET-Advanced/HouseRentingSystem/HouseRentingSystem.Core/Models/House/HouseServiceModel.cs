namespace HouseRentingSystem.Core.Models.House;

using System.ComponentModel;

public class HouseServiceModel : HouseIndexServiceModel
{
    [DisplayName("Price Per Month")]
    public decimal PricePerMonth { get; set; }

    [DisplayName("Is Rented")]
    public bool IsRented { get; set; }
}