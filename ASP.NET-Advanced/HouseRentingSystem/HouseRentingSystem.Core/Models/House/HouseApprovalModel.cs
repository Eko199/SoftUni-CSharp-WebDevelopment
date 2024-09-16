namespace HouseRentingSystem.Core.Models.House;

using System.ComponentModel;

public class HouseApprovalModel : HouseIndexServiceModel
{
    [DisplayName("Price Per Month")]
    public decimal PricePerMonth { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    [DisplayName("Agent Email")]
    public string AgentEmail { get; set; } = string.Empty;
}