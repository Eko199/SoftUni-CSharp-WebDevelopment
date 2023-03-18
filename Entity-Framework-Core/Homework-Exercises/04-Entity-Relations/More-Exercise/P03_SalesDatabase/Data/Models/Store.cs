namespace P03_SalesDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Store
{
    public Store()
    {
        Sales = new HashSet<Sale>();
    }

    [Key]
    public int StoreId { get; set; }

    [MaxLength(80)] 
    [Unicode] 
    public string Name { get; set; } = null!;

    public ICollection<Sale> Sales { get; set; }
}