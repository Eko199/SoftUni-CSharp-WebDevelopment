namespace CarDealer.DTOs.Import;

public class ImportCarDTO
{
    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int TraveledDistance { get; set; }

    public ICollection<int> PartsId { get; set; } = null!;
}