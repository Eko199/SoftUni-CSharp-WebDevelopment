namespace HouseRentingSystem.Infrastructure.Models;

using System.ComponentModel.DataAnnotations;
using static DataConstants.Category;

public class Category
{
    public int Id { get; init; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<House> Houses { get; init; } = new HashSet<House>();
}