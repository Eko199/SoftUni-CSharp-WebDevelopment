namespace HouseRentingSystem.Core.Models.House;

using System.ComponentModel.DataAnnotations;
using static Infrastructure.DataConstants.House;

public class HouseFormModel : HouseModel
{
    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [Range(typeof(decimal), MinPricePerMonth, MaxPricePerMonth, ConvertValueInInvariantCulture = true,
        ErrorMessage = "Price Per Month must be a positive number less than {2} leva.")]
    [Display(Name = "Price Per Month")]
    public decimal PricePerMonth { get; set; }

    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();
}