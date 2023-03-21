namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Album
{
    public Album()
    {
        Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(40)] 
    public string Name { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime ReleaseDate { get; set; }

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; }

    [NotMapped]
    public decimal Price => Songs.Sum(s => s.Price);
}