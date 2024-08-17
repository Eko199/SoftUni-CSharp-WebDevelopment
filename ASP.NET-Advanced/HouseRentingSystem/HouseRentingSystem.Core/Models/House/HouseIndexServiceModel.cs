using System.ComponentModel;

namespace HouseRentingSystem.Core.Models.House;

public class HouseIndexServiceModel : HouseModel
{
    public int Id { get; set; }

    [DisplayName("Image URL")]
    public string ImageUrl { get; set; } = string.Empty;
}