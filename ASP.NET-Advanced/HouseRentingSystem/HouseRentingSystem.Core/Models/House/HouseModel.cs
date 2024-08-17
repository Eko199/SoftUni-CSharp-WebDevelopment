namespace HouseRentingSystem.Core.Models.House;

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static Infrastructure.DataConstants.House;

public abstract class HouseModel
{
    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
    public string Address { get; set; } = string.Empty;

    public string GetInformation() => $"{Title.Replace(" ", "-")}-{GetAddress()}";

    private string GetAddress()
    {
        string address = string.Join("-", Address.Split(" ").Take(3));
        return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);
    }
}