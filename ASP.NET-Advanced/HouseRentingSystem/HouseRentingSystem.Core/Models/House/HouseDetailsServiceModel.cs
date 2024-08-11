namespace HouseRentingSystem.Core.Models.House;

using Agent;

public class HouseDetailsServiceModel : HouseServiceModel
{
    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public AgentServiceModel Agent { get; set; } = null!;
}