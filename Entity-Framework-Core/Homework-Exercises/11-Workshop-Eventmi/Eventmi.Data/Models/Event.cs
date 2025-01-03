﻿namespace Eventmi.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    [Required] 
    public string Place { get; set; } = null!;
}