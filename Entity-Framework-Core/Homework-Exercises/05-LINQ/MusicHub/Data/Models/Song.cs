﻿namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Song
{
    public Song()
    {
        SongPerformers = new HashSet<SongPerformer>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(20)] 
    public string Name { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreatedOn { get; set; }

    public Genre Genre { get; set; }

    public decimal Price { get; set; }

    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }
    public virtual Album? Album { get; set;}

    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }
    public virtual Writer Writer { get; set; } = null!;

    public virtual ICollection<SongPerformer> SongPerformers { get; set; }
}