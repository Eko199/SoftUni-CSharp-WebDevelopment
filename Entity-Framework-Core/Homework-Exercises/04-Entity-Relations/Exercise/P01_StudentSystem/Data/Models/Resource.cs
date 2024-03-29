﻿namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [MaxLength(50)] 
    [Unicode] 
    public string Name { get; set; } = null!;

    [Unicode(false)]
    public string? Url { get; set; }

    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;
}