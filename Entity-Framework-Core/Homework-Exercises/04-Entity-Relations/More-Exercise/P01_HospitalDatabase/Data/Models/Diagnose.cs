namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }

    [MaxLength(50)] 
    [Unicode] 
    public string Name { get; set; } = null!;

    [MaxLength(250)]
    [Unicode]
    public string? Comments { get; set; }

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}