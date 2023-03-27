namespace FastFood.Core.ViewModels.Employees;

using System.ComponentModel.DataAnnotations;

public class RegisterEmployeeInputModel
{
    [StringLength(30, MinimumLength = 3)] 
    public string Name { get; set; } = null!;

    [Range(15, 80)]
    public int Age { get; set; }

    public int PositionId { get; set; }

    [StringLength(30, MinimumLength = 3)] 
    public string Address { get; set; } = null!;
}