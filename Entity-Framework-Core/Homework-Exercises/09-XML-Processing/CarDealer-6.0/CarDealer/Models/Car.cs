namespace CarDealer.Models;

using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int Id { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public long TraveledDistance { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();    

    public ICollection<PartCar> PartsCars { get; set; } = new List<PartCar>();
}