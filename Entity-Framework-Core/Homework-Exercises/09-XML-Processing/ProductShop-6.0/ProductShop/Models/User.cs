namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    public User()
    {
        this.ProductsSold = new List<Product>();
        this.ProductsBought = new List<Product>();
    }

    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public ICollection<Product> ProductsSold { get; set; } = null!;
    public ICollection<Product> ProductsBought { get; set; } = null!;
}