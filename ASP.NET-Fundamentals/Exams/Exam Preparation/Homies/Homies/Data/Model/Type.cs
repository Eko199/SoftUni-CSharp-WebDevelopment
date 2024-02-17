namespace Homies.Data.Model;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Type
{
    [Key]
    [Comment("Unique type identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(DataConstants.TypeNameMaxLength)]
    [Comment("Type name")]
    public string Name { get; set; } = string.Empty;

    public ICollection<Event> Events { get; set; } = new HashSet<Event>();
}