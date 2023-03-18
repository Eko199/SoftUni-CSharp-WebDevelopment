namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

public class Visitation
{
    [Key]
    public int VisitationId { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(250)]
    [Unicode]
    public string? Comments { get; set; }

    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}